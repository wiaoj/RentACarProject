import { ToastrService } from 'ngx-toastr';
import { CarRentalAdd } from './../../models/carRental/carRentalAdd';
import { CarRental } from './../../models/carRental/carRental';
import { CarDetailByIdService } from './../../services/carDetail/car-detailById.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CreditCard } from './../../models/creditCard/creditCard';
import { CreditCardService } from './../../services/creditCard/credit-card.service';
import { CarService } from './../../services/car/car.service';
import { CarRentalService } from './../../services/carRental/car-rental.service';
import { CarDetailsById } from 'src/app/models/carDetailById/carDetailById';
import { CarDetailComponent } from './../car-detail/car-detail.component';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-car-rental-add',
  templateUrl: './car-rental-add.component.html',
  styleUrls: ['./car-rental-add.component.css'],
})
export class CarRentalAddComponent implements OnInit {
  carDetails: CarDetailsById[] = [];
  creditCards: CreditCard[];
  creditCard: CreditCard[];
  minStartDate: Date = new Date();
  minEndDate: Date = new Date();
  startDate: Date = new Date();
  endDate: Date = new Date();
  diff: number = 0;
  money: number = 0;

  carId: number;
  cardNumber: string;
  rentDays: number;
  rentDate: number;
  totalPrice: number;

  dailyPrice: number = 0;

  creditCardForm: FormGroup;
  paymentPage: boolean = false;
  checkBox: boolean = false;
  isCardExist: boolean = true;
  constructor(
    private carRentalService: CarRentalService,
    private carDetailByIdService: CarDetailByIdService,
    private creditCardService: CreditCardService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private toastr: ToastrService
  ) //private modalService:NgbModal,
  {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      if (!params['carId']) {
        this.router.navigateByUrl('/carDetails');
        return;
      }
      this.checkIfCarExists(params['carId']);
    });
    this.createCreditCardForm();
  }
  setMinEndDate() {
    this.minEndDate = this.startDate;
  }
  calculateDiff() {
    let startDate = new Date(this.startDate);
    let endDate = new Date(this.endDate);
    let diff = Math.abs(endDate.getTime() - startDate.getTime());
    this.diff = Math.ceil(diff / (1000 * 3600 * 24));
    this.money = this.diff * this.dailyPrice;
  }

  checkIfCarExists(id: number) {
    this.carDetailByIdService.getCarDetails(id).subscribe((response) => {
      //this.carDetails = response.data;
      response.data.forEach((element) => {
        this.carId = element.id;
        this.dailyPrice = element.dailyPrice;
      });
    });
  }

  getCards() {
    this.creditCardService.getCards().subscribe((response) => {
      this.creditCards = response.data;
      if (response.data.length == 0) {
        this.isCardExist = false;
      } else {
        this.isCardExist = true;
      }
    });
  }

  getCardById(id: number) {
    this.creditCardService.getCardById(id).subscribe((response) => {
      this.creditCard = response.data;
    });
  }

  createCreditCardForm() {
    this.creditCardForm = this.formBuilder.group({
      nameOnTheCard: [''],
      cardNumber: [''],
      expirationDate: [''],
      cvv: [''],
    });
  }
  checkBoxTicked(event: any) {
    this.checkBox = event.target.checked;
  }

  goToPayment() {
    this.paymentPage = true;
    this.getCards();
  }
  goToBack() {
    this.paymentPage = false;
  }

  saveCreditCard() {
    if (this.creditCardForm.valid) {
      let newModel = Object.assign({}, this.creditCardForm.value);
      this.creditCardService.saveCard(newModel).subscribe((response) => {
        console.log(response);
      });
    }
    this.rentCar();
  }

  rentCar() {
    this.getCardById(5);
    if (this.isCardExist == true) {
      let newRental: CarRentalAdd = {
        carId: this.carId,
        customerId: 5,
        rentDate: this.startDate,
        returnDate: this.endDate,
      };
      this.carRentalService.addCarRentals(newRental).subscribe((response) => {
        response.data;
        this.toastr.success(response.message);
      });
    }

    //this.creditCardService.payment(newCreditCard).subscribe(response=>{
    //console.log(response.data)
    //});
  }
  saveModal(content: any) {
    //this.modalService.open(content);
  }
  closeSaveModel() {
    //this.modalService.dismissAll();
  }
}
