import { CarDetailsById } from 'src/app/models/carDetailById/carDetailById';
import { ActivatedRoute, Router } from '@angular/router';
import { Car } from 'src/app/models/car/car';
import { ColorService } from './../../services/color/color.service';
import { BrandService } from './../../services/brand/brand.service';
import { CarService } from './../../services/car/car.service';
import { ToastrService } from 'ngx-toastr';
import { Color } from 'src/app/models/color/color';
import { Brand } from './../../models/brand/brand';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-car-update',
  templateUrl: './car-update.component.html',
  styleUrls: ['./car-update.component.css'],
})
export class CarUpdateComponent implements OnInit {
  carUpdateForm: FormGroup;
  car:Car[];
  brands: Brand[];
  colors: Color[];

  constructor(
    private formbuilder: FormBuilder,
    private toastr: ToastrService,
    private router:Router,
    private carService: CarService,
    private brandService: BrandService,
    private colorService: ColorService,
    private activatedRoute:ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.getBrands();
    this.getColors();
    this.getCarIdFromParam();
    this.createCarUpdateForm();
  }

  createCarUpdateForm() {

    this.carUpdateForm = this.formbuilder.group({
      name: ['', Validators.required],
      brandId: ['', Validators.required],
      colorId: ['', Validators.required],
      modelYear: ['', Validators.required],
      dailyPrice: ['', Validators.required],
      description: ['', Validators.required],
    });
  }

  getCarIdFromParam() {
    this.activatedRoute.params.subscribe((params) => {
      if (params['carId']){
        this.getCarById(params['carId']);
      }
    });
  }

  getCarById(carId: number) {
    this.carService.getCarsDetailsById(carId).subscribe((response) => {
      this.car = response.data
    });
  }


  getBrands() {
    this.brandService.getBrands().subscribe((response) => {
      this.brands = response.data;
    });
  }
  getColors() {
    this.colorService.getColors().subscribe((response) => {
      this.colors = response.data;
    });
  }

  update() {
    let carId;
    this.car.forEach(data=>carId = data.id)
    if (this.carUpdateForm.valid) {
      let carModel: Car = {id:carId, ...this.carUpdateForm.value};
      console.log(carModel)
      this.carService.update(carModel).subscribe(
        (response) => {
          this.toastr.success(response.message);
          this.router.navigate(['', 'cars']);//goto mainPage
        },
        (responseError) => {
          if (responseError.error.ValidationErrors.length > 0) {
            for (
              let i = 0;
              i < responseError.error.ValidationErrors.length;
              i++
            ) {
              this.toastr.error(
                responseError.error.ValidationErrors[i].ErrorMessage
              );
            }
          }
        }
      );
    } else {
      this.toastr.error('Formunuz eksik', 'Dikkat');
    }
  }
}
