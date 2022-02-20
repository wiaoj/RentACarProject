import { ListResponseModel } from 'src/app/models/listResponseModel';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CarRental } from 'src/app/models/carRental/carRental';
import { ResponseModel } from 'src/app/models/responseModel';

@Injectable({
  providedIn: 'root',
})
export class CarRentalService {
  apiUrl = 'https://localhost:44388/api/rentals';

  constructor(private httpClient: HttpClient) {}

  getCarRentals(): Observable<ListResponseModel<CarRental>> {
    return this.httpClient.get<ListResponseModel<CarRental>>(this.apiUrl);
  }

  addCarRental(rental: any): Observable<ResponseModel> {
    let newPAth = `${this.apiUrl}/add`;
    return this.httpClient.post<ResponseModel>(newPAth, rental);
  }

  checkIfCarIsAvailable(
    carId: number,
    rentDate: string,
    returnDate: string
  ): Observable<ResponseModel> {
    let newPath =
      this.apiUrl +
      `/checkifcarisavailable?carId=${carId}&rentDate=${rentDate}&returnDate=${returnDate}`;
      //`${}`
    return this.httpClient.get<ResponseModel>(newPath);
  }

  getCarRentalsDetails(): Observable<ListResponseModel<CarRental>> {
    return this.httpClient.get<ListResponseModel<CarRental>>(
      this.apiUrl + '/rentaldetails'
    );
  }
}
