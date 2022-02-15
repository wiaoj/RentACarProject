export interface CarDetailsById {
  id: number;
  name: string;
  brandName: string;
  colorName: string;
  modelYear: number;
  dailyPrice: number;
  rentDate: Date;
  returnDate: Date;
  description: string;
  imagePaths: string[];
}
