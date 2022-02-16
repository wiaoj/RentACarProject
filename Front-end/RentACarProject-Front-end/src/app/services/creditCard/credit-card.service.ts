import { ResponseModel } from './../../models/responseModel';
import { CreditCard } from './../../models/creditCard/creditCard';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ListResponseModel } from 'src/app/models/listResponseModel';

@Injectable({
  providedIn: 'root',
})
export class CreditCardService {
  apiUrl = 'https://localhost:44388/api/CreditCards';

  constructor(private httpClient: HttpClient) {}

  getCardByCustomerId(id: number): Observable<ListResponseModel<CreditCard>> {
    let newPath = this.apiUrl + '/getbycustomerid?id=' + id;
    return this.httpClient.get<ListResponseModel<CreditCard>>(newPath);
  }

  payment(
    creditCard: CreditCard,
    carId: number
  ): Observable<ListResponseModel<CreditCard>> {
    let newPath = this.apiUrl + '/pay?carId=' + carId;
    return this.httpClient.post<ListResponseModel<CreditCard>>(
      newPath,
      creditCard
    );
  }
  saveCard(creditCard: CreditCard): Observable<ResponseModel> {
    let newPath = this.apiUrl;
    return this.httpClient.post<ResponseModel>(newPath, creditCard);
  }
}
