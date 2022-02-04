import { CarImage } from './../../models/carImage/carImage';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ListResponseModel } from 'src/app/models/listResponseModel';

@Injectable({
  providedIn: 'root',
})
export class CarImageService {
  apiUrl = 'https://localhost:44388/api/carimages';

  constructor(private httpClient: HttpClient) {}
  getCarImages(): Observable<ListResponseModel<CarImage>> {
    return this.httpClient.get<ListResponseModel<CarImage>>(this.apiUrl);
  }

  getCarImagesById(id:number): Observable<ListResponseModel<CarImage>> {
    let newPath = this.apiUrl + "/getbyid?id=" + id
    return this.httpClient.get<ListResponseModel<CarImage>>(newPath);
  }

  getCarImagesByCarId(carId:number): Observable<ListResponseModel<CarImage>> {
    let newPath = this.apiUrl + "/getimagesbycarid?carId=" + carId
    return this.httpClient.get<ListResponseModel<CarImage>>(newPath);
  }
}
