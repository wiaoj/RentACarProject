import { CarComponent } from './../car/car.component';
import { ToastrService } from 'ngx-toastr';
import { BrandService } from './../../services/brand/brand.service';
import { Brand } from './../../models/brand/brand';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-brand',
  templateUrl: './brand.component.html',
  styleUrls: ['./brand.component.css'],
})
export class BrandComponent implements OnInit {
  brands: Brand[] = [];
  currentBrand: Brand;
  brandId:number=0;
  filterText: string = '';
  //dataLoaded = false;
  constructor(
    private brandService: BrandService,
    private carComponent: CarComponent,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.getBrands();
  }

  getBrands() {
    this.brandService.getBrands().subscribe((response) => {
      this.brands = response.data;
      //this.dataLoaded = true;
    });
  }

  setCurrentBrand() {
    this.carComponent.brandId = this.brandId;
  }
  clearCurrentBrand() {
    this.currentBrand = { id: 0, name: '' };
    this.brandId=0;
    this.setCurrentBrand();
  }

  getCurrentBrandClass(brand: Brand) {
    if (brand == this.currentBrand) {
      return 'list-group-item list-group-item-action list-group-item-info';
    } else {
      return 'list-group-item list-group-item-action list-group-item-primary';
    }
  }

  getAllBrandClass() {
    if (this.currentBrand) {
      return 'list-group-item list-group-item-action list-group-item-primary';
    } else {
      //bak
      return 'list-group-item list-group-item-action list-group-item-info';
    }
  }

  clearInputBox() {
    this.clearCurrentBrand();
    this.filterText = '';
  }
}
