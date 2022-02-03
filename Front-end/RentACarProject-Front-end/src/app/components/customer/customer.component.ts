import { CustomerService } from './../../services/customer/customer.service';
import { Customer } from './../../models/customer/customer';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css'],
})
export class CustomerComponent implements OnInit {
  customers: Customer[] = [];
  dataLoaded = false;
  constructor(private customerService: CustomerService) {}

  ngOnInit(): void {
    //this.getCustomers();
    this.getCustomerDetails();
  }

  getCustomers() {
    this.customerService.getCustomers().subscribe((response) => {
      this.customers = response.data;
      this.dataLoaded = true;
    });
  }

  getCustomerDetails() {
    this.customerService.getCustomersDetails().subscribe((response) => {
      this.customers = response.data;
      this.dataLoaded = true;
    });
  }
}
