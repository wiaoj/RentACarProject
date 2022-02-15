import { SingleResponseModel } from './../../models/singleResponseModel';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ListResponseModel } from './../../models/listResponseModel';
import { CarDetailsById } from 'src/app/models/carDetailById/carDetailById';

@Injectable({
  providedIn: 'root',
})
export class CarDetailByIdService {
  apiUrl = 'https://localhost:44388/api/cars/';
  constructor(private httpClient: HttpClient) {}

  getCarDetails(id: number): Observable<ListResponseModel<CarDetailsById>> {
    let newPath = this.apiUrl + 'getcardetailsbyid?id=' + id;
    return this.httpClient.get<ListResponseModel<CarDetailsById>>(newPath);
  }
  getCarDetail(id: number): Observable<SingleResponseModel<CarDetailsById>> {
    let newPath = this.apiUrl + 'getcardetailsbyid?id=' + id;
    return this.httpClient.get<SingleResponseModel<CarDetailsById>>(newPath);
  }
}
