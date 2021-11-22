import { Pipe, PipeTransform } from '@angular/core';

@Pipe({name: 'getMapValue'})
export class GetMapValuePipe implements PipeTransform {
  transform(map: Map<any, any>, key: any): any {
    console.log('function executed');
    return map.get(key);
  }
}