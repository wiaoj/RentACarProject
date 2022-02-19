import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BrandService } from './../../services/brand/brand.service';
import { Brand } from 'src/app/models/brand/brand';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-brand-update',
  templateUrl: './brand-update.component.html',
  styleUrls: ['./brand-update.component.css'],
})
export class BrandUpdateComponent implements OnInit {
  dataLoaded: boolean = false;
  selectedBrand:boolean=false;
  brands: Brand[] = [];
  brand:Brand;
  brandUpdateForm: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private router:Router,
    private brandService: BrandService) {}

  ngOnInit(): void {
    this.getBrands();
    this.createBrandUpdateForm();
  }

  createBrandUpdateForm(brandName:String = "Select brand") {
    this.brandUpdateForm = this.formBuilder.group({
      name: [brandName, Validators.required],
    });
  }

  getBrands() {
    this.brandService.getBrands().subscribe((response) => {
      this.brands = response.data;
      this.dataLoaded = true;
    });
  }

  selectBrand(brand:Brand){
    this.selectedBrand = true;
    this.brand = brand;
    this.createBrandUpdateForm(brand.name);
  }

  update() {
    if (this.brandUpdateForm.valid) {
      let brandModel: Brand = {id: this.brand.id, ...this.brandUpdateForm.value};
      this.brandService.update(brandModel).subscribe(
        (response) => {
          this.toastr.success(response.message);
          window.location.reload(); //refresh page
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
