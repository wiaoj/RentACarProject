import { ListResponseModel } from './../../models/listResponseModel';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Car } from 'src/app/models/car/car';

@Injectable({
  providedIn: 'root',
})
export class CarService {
  apiUrl = 'https://localhost:44388/api/cars';

  constructor(private httpClient: HttpClient) {}
  getCars(): Observable<ListResponseModel<Car>> {
    let newPath = this.apiUrl;
    return this.httpClient.get<ListResponseModel<Car>>(newPath);
  }

  getCarsDetails(): Observable<ListResponseModel<Car>> {
    let newPath = this.apiUrl + '/getcarsdetails';
    return this.httpClient.get<ListResponseModel<Car>>(newPath);
  }

  getCarsByBrandId(id: number): Observable<ListResponseModel<Car>> {
    let newPath = this.apiUrl + '/getbybrandid?id=' + id;
    return this.httpClient.get<ListResponseModel<Car>>(newPath);
  }
  getCarsByColorId(id: number): Observable<ListResponseModel<Car>> {
    let newPath = this.apiUrl + '/getbycolorid?id=' + id;
    return this.httpClient.get<ListResponseModel<Car>>(newPath);
  }
  getCarsDetailsById(id: number): Observable<ListResponseModel<Car>> {
    let newPath = this.apiUrl + '/getbycarid?id=' + id;
    return this.httpClient.get<ListResponseModel<Car>>(newPath);
  }
  getCarsByBrandIdAndColorId(brandId: number, colorId: number): Observable<ListResponseModel<Car>> {
    let newPath = this.apiUrl + '/getcardetailsbybrandidandcolorid?brandid=' + brandId + '&colorid=' + colorId;
    return this.httpClient.get<ListResponseModel<Car>>(newPath);
  }
}
