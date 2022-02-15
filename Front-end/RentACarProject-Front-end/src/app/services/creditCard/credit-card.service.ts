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

  getCards(): Observable<ListResponseModel<CreditCard>> {
    let newPath = this.apiUrl;
    return this.httpClient.get<ListResponseModel<CreditCard>>(newPath);
  }

  getCardById(id:number): Observable<ListResponseModel<CreditCard>> {
    let newPath = this.apiUrl + "/getbyid?id=" + id;
    return this.httpClient.get<ListResponseModel<CreditCard>>(newPath);
  }
  payment(creditCard: CreditCard[]): Observable<ListResponseModel<CreditCard>> {
    let newPath = this.apiUrl + '/pay';
    return this.httpClient.post<ListResponseModel<CreditCard>>(newPath,creditCard);
  }
  saveCard(creditCard: CreditCard): Observable<CreditCard> {
    let newPath = this.apiUrl;
    return this.httpClient.post<CreditCard>(newPath, creditCard);
  }
}
