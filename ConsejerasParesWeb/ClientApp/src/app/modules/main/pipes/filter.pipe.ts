import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

  transform(value: any, arg: any, page: number = 0): any {
    // if(arg === '' || arg.length < 3) return value;
    if ( arg === '') return value;
    const result= [];
    for(const name of value){
      if(name.firstName.toLowerCase().indexOf(arg.toLowerCase()) > -1 || name.firstLastName.toLowerCase().indexOf(arg.toLowerCase()) > -1){
        console.log(name);
        result.push(name);
      };
      // if(name.firstLastName.toLowerCase().indexOf(arg.toLowerCase()) > -1){
      //   result.push(name);
      // };
    };
    return result.slice(page,page +5);
  }

}
