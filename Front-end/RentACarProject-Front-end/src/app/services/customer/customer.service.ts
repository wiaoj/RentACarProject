import { ListResponseModel } from './../../models/listResponseModel';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Customer } from './../../models/customer/customer';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  apiUrl = 'https://localhost:44388/api/customers';

  constructor(private httpClient: HttpClient) {}
  getCustomers(): Observable<ListResponseModel<Customer>> {
    return this.httpClient.get<ListResponseModel<Customer>>(this.apiUrl);
  }

  getCustomersDetails(): Observable<ListResponseModel<Customer>> {
    let newPath = `${this.apiUrl}/customerdetails`;
    return this.httpClient.get<ListResponseModel<Customer>>(newPath);
  }
}
