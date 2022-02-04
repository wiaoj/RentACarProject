import { ListResponseModel } from 'src/app/models/listResponseModel';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CarRental } from 'src/app/models/carRental/carRental';

@Injectable({
  providedIn: 'root',
})
export class CarRentalService {
  apiUrl = 'https://localhost:44388/api/rentals';

  constructor(private httpClient: HttpClient) {}
  getCarRentals(): Observable<ListResponseModel<CarRental>> {
    return this.httpClient.get<ListResponseModel<CarRental>>(this.apiUrl);
  }

  getCarRentalsDetails(): Observable<ListResponseModel<CarRental>> {
    return this.httpClient.get<ListResponseModel<CarRental>>(
      this.apiUrl + '/rentaldetails'
    );
  }
}