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
  carDetails: CarDetailsById[];
  constructor(private carDetailByIdService: CarDetailByIdService) {}

  ngOnInit(): void {
   this.getCarDetails(2);
  }

  getCarDetails(id: number) {
    this.carDetailByIdService.getCarDetails(id).subscribe((response) => {
      this.carDetails = response.data;
    });
  }
  getImage(imgSource:string){
    let imageUrl = "https://localhost:44388/Uploads/Images/" + imgSource;
    return imageUrl;
  }
}
