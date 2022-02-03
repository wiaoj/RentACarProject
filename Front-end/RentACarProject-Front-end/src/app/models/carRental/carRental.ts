export interface CarRental {
  id: number;
  customerFirstName: string;
  customerLastName: string;
  customerCompanyName: string;
  carName: string;
  brandName: string;
  colorName: string;
  dailyPrice: number;
  rentDate: Date;
  returnDate: Date;
}
