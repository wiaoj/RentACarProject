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
  filterText: string = '';
  //dataLoaded = false;
  constructor(
    private brandService: BrandService,
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

  setCurrentBrand(brand: Brand) {
    this.currentBrand = brand;
    this.toastr.success(
      this.currentBrand.name,
      this.currentBrand.id.toString()
    );
  }
  clearCurrentBrand() {
    this.currentBrand = { id: 0, name: '' };
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
