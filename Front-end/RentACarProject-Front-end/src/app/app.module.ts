import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { BrandComponent } from './components/brand/brand.component';
import { CarComponent } from './components/car/car.component';
import { ColorComponent } from './components/color/color.component';
import { CustomerComponent } from './components/customer/customer.component';
import { CarRentalComponent } from './components/car-rental/car-rental.component';
import { CarDetailComponent } from './components/car-detail/car-detail.component';
import { CarRentalAddComponent } from './components/car-rental-add/car-rental-add.component';

import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrandFilterPipePipe } from './pipes/brand/brand-filter-pipe.pipe';
import { ColorFilterPipePipe } from './pipes/color/color-filter-pipe.pipe';
import { CarFilterPipePipe } from './pipes/car/car-filter-pipe.pipe';
import { CardNumberPipePipe } from './pipes/creditCard/card-number-pipe.pipe';
import { DatePipe } from '@angular/common';
@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    BrandComponent,
    CarComponent,
    ColorComponent,
    CustomerComponent,
    CarRentalComponent,
    CarDetailComponent,
    BrandFilterPipePipe,
    ColorFilterPipePipe,
    CarFilterPipePipe,
    CarRentalAddComponent,
    CardNumberPipePipe,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule, //[(ngModel)]
    ReactiveFormsModule,
    BrowserAnimationsModule, // required animations module for toastr
    ToastrModule.forRoot({
      positionClass:"toast-top-right",
      autoDismiss:true,
      closeButton:true,
      maxOpened:3,
      progressBar:true
    })
  ],
  providers: [
    DatePipe,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
