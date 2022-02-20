import { LocalStorageService } from './../../services/localStorage/local-storage.service';
import { ToastrService } from 'ngx-toastr';
import { CarDetailByIdService } from './../../services/carDetail/car-detailById.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CreditCard } from './../../models/creditCard/creditCard';
import { CreditCardService } from './../../services/creditCard/credit-card.service';
import { CarRentalService } from './../../services/carRental/car-rental.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-car-rental-add',
  templateUrl: './car-rental-add.component.html',
  styleUrls: ['./car-rental-add.component.css'],
})
export class CarRentalAddComponent implements OnInit {
  currentDate: any;
  returnDate: any;
  isCarAvailable: boolean;
  messageToDisplay: string;
  carId: number;
  isSaveCardChecked: boolean;
  creditCards: CreditCard[];
  hasSavedCard: boolean = false;
  cardFromDropdown: CreditCard;

  paymentForm: FormGroup;
  months: string[] = [
    '01',
    '02',
    '03',
    '04',
    '05',
    '06',
    '07',
    '08',
    '09',
    '10',
    '11',
    '12',
  ];
  years: string[] = [
    '2022',
    '2023',
    '2024',
    '2025',
    '2026',
    '2027',
    '2028',
    '2029',
    '2030',
    '2031',
    '2032',
    '2033',
  ];
  constructor(
    private carRentalService: CarRentalService,
    private carDetailByIdService: CarDetailByIdService,
    private creditCardService: CreditCardService,
    private localStorageService: LocalStorageService,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private datePipe: DatePipe //private modalService:NgbModal,
  ) {}

  ngOnInit(): void {
    this.setDay();
    this.activatedRoute.params.subscribe((params) => {
      this.carId = params['carId'];
    });

    this.createPaymentForm();

    this.paymentForm.valueChanges.subscribe(console.log);

    this.getCards();
  }

  createPaymentForm() {
    this.paymentForm = this.formBuilder.group({
      fullName: ['', Validators.required],
      cardNumber: ['', Validators.required],
      expirationMonth: ['01', Validators.required],
      expirationYear: ['2022', Validators.required],
      cvv: ['', Validators.required],
    });
  }

  saveCreditCard() {
    let card = {
      customerId: 2,
      fullName: this.paymentForm.value.fullName,
      cardNumber: this.paymentForm.value.cardNumber,
      expirationYear: this.paymentForm.value.expirationYear, // + "-" + this.paymentForm.value.expirationMonth + "-" + "01"
      expirationMonth: this.paymentForm.value.expirationMonth,
      cvv: this.paymentForm.value.cvv,
    };

    let cardToAdd = Object.assign(card);
    this.creditCardService.saveCard(cardToAdd).subscribe((response) => {
      if (response.success) {
        this.toastr.success('Card saved successfully.');
      } else if (response.success == false) {
        this.toastr.error('An error occured when saving the card. Try later.');
      }
    });
  }

  pay() {
    let card: CreditCard;
    card = {
      id: 0,
      customerId: 2,
      fullName: this.paymentForm.value.fullName,
      cardNumber: this.paymentForm.value.cardNumber,
      cvv: this.paymentForm.value.cvv,
      expirationMonth: this.paymentForm.value.expirationMonth,
      expirationYear: this.paymentForm.value.expirationYear,
    };
    if (this.hasSavedCard) {
      card = {
        id: 0,
        customerId: 2,
        cardNumber: this.cardFromDropdown.cardNumber,
        cvv: this.cardFromDropdown.cvv,
        fullName: this.cardFromDropdown.fullName,
        expirationMonth: this.cardFromDropdown.expirationMonth, //.split('-')[1]
        expirationYear: this.cardFromDropdown.expirationYear, //.split('-')[0]
      };
    }
    if (this.isSaveCardChecked != true) {
      if (this.paymentForm.valid || this.hasSavedCard) {
        this.creditCardService
          .payment(card, this.carId)
          .subscribe((response) => {
            if (response.success) {
              this.toastr.success('Payment has been made successfully');
              this.rentCar();
            } else {
              this.toastr.error('An error occured! Try later.');
            }
          });
      } else {
        this.toastr.error('Complete the form!');
      }
    } else if (this.isSaveCardChecked == true) {
      if (this.paymentForm.valid) {
        this.creditCardService
          .payment(card, this.carId)
          .subscribe((response) => {
            if (response.success) {
              this.toastr.success('Payment has been made successfully');
              this.rentCar();
              this.saveCreditCard();
            } else {
              this.toastr.error('An error occured! Try later.');
            }
          });
      } else {
        this.toastr.error('Complete the form!');
      }
    }
  }

  checkIfCarIsAvailable(carId: number, rentDate: string, returnDate: string) {
    if (rentDate <= returnDate) {
      this.carRentalService
        .checkIfCarIsAvailable(carId, rentDate, returnDate)
        .subscribe(
          (response) => {
            this.isCarAvailable = response.success;
            this.messageToDisplay = response.message;
            this.toastr.success(response.message);
          },
          (responseError) => {
            this.toastr.error(responseError.error.message);
            console.log(responseError.error.message);
          }
        );
    } else {
      this.toastr.error('Please select date');
      this.setDay();
    }
  }

  setDay() {
    this.currentDate = this.datePipe.transform(new Date(), 'yyyy-MM-dd');
    this.returnDate = this.datePipe.transform(new Date(), 'yyyy-MM-dd');
  }

  getCurrentClassOfPayButton() {
    if (this.isCarAvailable) {
      return 'btn btn-primary';
    } else {
      return 'btn btn-primary disabled';
    }
  }

  rentCar() {
    let values = this.returnDate.split('-');
    let returnDataConverted = this.datePipe.transform(
      new Date(+values[0], +values[1] - 1, +values[2]),
      'yyyy-MM-dd'
    );
    let rental = {
      carId: this.carId,
      customerId: 2,
      rentDate: this.currentDate,
      returnDate: returnDataConverted,
    };
    this.carRentalService.addCarRental(rental).subscribe(
      (response) => {
        if (response.success) {
          this.toastr.success('The rent has been successfully completed.');
        } else {
          this.toastr.error('An error occured! Try later.');
        }
      },
      (responseError) => {
        this.toastr.error(responseError.error.message);
        console.log(responseError.error.message);
      }
    );
  }

  getCards() {
    //let userString: any = this.localStorageService.get('user');
    //let userId: number = JSON.parse(userString).id;
    this.creditCardService.getCardByCustomerId(2).subscribe((response) => {
      this.creditCards = response.data;
      if (this.creditCards.length > 0) {
        this.hasSavedCard = true;
      } else {
        this.hasSavedCard = false;
      }
    });
  }
  setHasSavedCardFalse() {
    this.hasSavedCard = false;
  }
}
