import { Brand } from './../../models/brand/brand';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'brandFilterPipe'
})
export class BrandFilterPipePipe implements PipeTransform {

  transform(value: Brand[], filterText: string): Brand[] {
    filterText = filterText ? filterText.toLocaleLowerCase() : "";
    return filterText ? value.filter((b:Brand)=>
    b.name.toLocaleLowerCase().indexOf(filterText) !== -1) : value;
    //filterText -1 den farklıysa yani varsa onları yeni array yapıp onu döndürüyor
  }

}
