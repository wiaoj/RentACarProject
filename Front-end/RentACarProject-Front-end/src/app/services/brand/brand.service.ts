import { ResponseModel } from './../../models/responseModel';
import { ListResponseModel } from './../../models/listResponseModel';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Brand } from 'src/app/models/brand/brand';

@Injectable({
  providedIn: 'root',
})
export class BrandService {
  apiUrl = 'https://localhost:44388/api/brands';

  constructor(private httpClient: HttpClient) {}
  getBrands(): Observable<ListResponseModel<Brand>> {
    return this.httpClient.get<ListResponseModel<Brand>>(this.apiUrl);
  }
  add(brand: Brand):Observable<ResponseModel> {
    let newPath = `${this.apiUrl}/add`;
    return this.httpClient.post<ResponseModel>(newPath, brand);
  }
  update(brand: Brand):Observable<ResponseModel> {
    let newPath = `${this.apiUrl}/update`;
    return this.httpClient.post<ResponseModel>(newPath, brand);
  }
}
