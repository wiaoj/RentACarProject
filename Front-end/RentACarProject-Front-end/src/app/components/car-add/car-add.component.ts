import { BrandService } from './../../services/brand/brand.service';
import { ColorService } from './../../services/color/color.service';
import { Color } from './../../models/color/color';
import { Brand } from './../../models/brand/brand';
import { CarService } from './../../services/car/car.service';
import { ToastrService } from 'ngx-toastr';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-car-add',
  templateUrl: './car-add.component.html',
  styleUrls: ['./car-add.component.css'],
})
export class CarAddComponent implements OnInit {
  carAddForm: FormGroup;
  brands:Brand[];
  colors:Color[];

  constructor(
    private formbuilder: FormBuilder,
    private toastr: ToastrService,
    private carService: CarService,
    private brandService:BrandService,
    private colorService:ColorService
  ) {}

  ngOnInit(): void {
    this.getBrands();
    this.getColors();
    this.createCarAddForm();
  }

  createCarAddForm(){
    this.carAddForm = this.formbuilder.group({
      name:["",Validators.required],
      brandId:["",Validators.required],
      colorId:["",Validators.required],
      modelYear:["",Validators.required],
      dailyPrice:["",Validators.required],
      description:["",Validators.required],
    })
  }

  getBrands(){
    this.brandService.getBrands().subscribe(response=>{
      this.brands = response.data;
    })
  }
  getColors(){
    this.colorService.getColors().subscribe(response=>{
      this.colors = response.data;
    })
  }

  add(){
    if (this.carAddForm.valid) {
      let carModel = Object.assign({}, this.carAddForm.value);
      this.carService.add(carModel).subscribe(
        (response) => {
          this.toastr.success(response.message);
        },
        (responseError) => {
          if (responseError.error.ValidationErrors.length > 0) {
            for (let i = 0; i < responseError.error.ValidationErrors.length; i++) {
              this.toastr.error(responseError.error.ValidationErrors[i].ErrorMessage);
            }
          }
        }
      );
    } else {
      this.toastr.error('Formunuz eksik', 'Dikkat');
    }
  }
}
