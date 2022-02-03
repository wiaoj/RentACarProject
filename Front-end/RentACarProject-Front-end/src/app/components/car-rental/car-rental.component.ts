import { CarRentalService } from './../../services/carRental/car-rental.service';
import { CarRental } from './../../models/carRental/carRental';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-car-rental',
  templateUrl: './car-rental.component.html',
  styleUrls: ['./car-rental.component.css'],
})
export class CarRentalComponent implements OnInit {
  carRentals: CarRental[] = [];
  dataLoaded = false;
  constructor(private carRentalService: CarRentalService) {}

  ngOnInit(): void {
    //this.getCarRentals();
    this.getCarRentalsDetails();
  }

  getCarRentals() {
    this.carRentalService.getCarRentals().subscribe((response) => {
      this.carRentals = response.data;
      this.dataLoaded = true;
    });
  }

  getCarRentalsDetails() {
    this.carRentalService.getCarRentalsDetails().subscribe((response) => {
      this.carRentals = response.data;
      console.log(this.carRentals);
      this.dataLoaded = true;
    });
  }
}
