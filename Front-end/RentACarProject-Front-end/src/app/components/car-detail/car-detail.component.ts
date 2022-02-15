import { CarImageService } from './../../services/carImage/car-image.service';
import { CarImage } from './../../models/carImage/carImage';
import { ActivatedRoute } from '@angular/router';
import { CarDetailsById } from '../../models/carDetailById/carDetailById';
import { Component, OnInit } from '@angular/core';
import { CarDetailByIdService } from 'src/app/services/carDetail/car-detailById.service';

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.css'],
})
export class CarDetailComponent implements OnInit {
  imageUrl: string = 'https://localhost:44388/uploads/images/';
  carDetails: CarDetailsById[]=[];
  imagePaths: CarImage[] = [];
  showImageButton: boolean = false;
  constructor(
    private carDetailByIdService: CarDetailByIdService,
    private carImageService: CarImageService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      if (params['carId']) {
        this.getCarDetails(params['carId']);
        this.getImage(params['carId']);
      }
    });
  }

  getCarDetails(id: number) {
    this.carDetailByIdService.getCarDetails(id).subscribe((response) => {
      this.carDetails = response.data;
    });
  }
  getImage(carId: number) {
    this.carImageService.getCarImagesByCarId(carId).subscribe((response) => {
      this.imagePaths = response.data;
      if (this.imagePaths.length > 1) {
        this.showImageButton = true;
      }
    });
  }
  showImageSrc(imagePath: string) {
    return this.imageUrl + imagePath;
  }
}
