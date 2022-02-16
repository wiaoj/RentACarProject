import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'cardNumberPipe',
})
export class CardNumberPipePipe implements PipeTransform {
  transform(value: string, ...args: any): string {
    let cardNo: string = value.slice(-4);
    return 'ends with ...${cardNo}';
  }
}
