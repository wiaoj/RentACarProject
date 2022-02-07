import { Car } from './../../models/car/car';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'carFilterPipe'
})
export class CarFilterPipePipe implements PipeTransform {

  transform(value: Car[], filterText:string): Car[] {
    filterText = filterText ? filterText.toLocaleLowerCase() : "";
    return filterText ? value.filter((c:Car)=>
    c.name.toLocaleLowerCase().indexOf(filterText) !== -1) : value;
  }

}
