import { RegisterComponent } from './components/auth/register/register.component';
import { LoginComponent } from './components/auth/login/login.component';
import { LoginGuard } from './guards/login.guard';
import { CarUpdateComponent } from './components/car-update/car-update.component';
import { ColorUpdateComponent } from './components/color-update/color-update.component';
import { BrandUpdateComponent } from './components/brand-update/brand-update.component';
import { CarAddComponent } from './components/car-add/car-add.component';
import { ColorAddComponent } from './components/color-add/color-add.component';
import { BrandAddComponent } from './components/brand-add/brand-add.component';
import { CarRentalAddComponent } from './components/car-rental-add/car-rental-add.component';
import { CarDetailComponent } from './components/car-detail/car-detail.component';
import { CarComponent } from './components/car/car.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: CarComponent },
  { path: 'cars', component: CarComponent },
  { path: 'cars/brand/:brandId', component: CarComponent },
  { path: 'cars/color/:colorId', component: CarComponent },
  { path: 'cars/details/:carId', component: CarDetailComponent },
  { path: 'cars/rental/add/:carId', component: CarRentalAddComponent },

  { path: 'brands/add', component: BrandAddComponent, canActivate:[LoginGuard] },
  { path: 'colors/add', component: ColorAddComponent, canActivate:[LoginGuard] },
  { path: 'cars/add', component: CarAddComponent, canActivate:[LoginGuard] },

  { path: 'brands/update', component: BrandUpdateComponent, canActivate:[LoginGuard] },
  { path: 'colors/update', component: ColorUpdateComponent, canActivate:[LoginGuard] },
  { path: 'cars/update/:carId', component: CarUpdateComponent, canActivate:[LoginGuard] },

  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
