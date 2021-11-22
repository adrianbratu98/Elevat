import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GetMapValuePipe } from './pipes/get-map-value.pipe';



@NgModule({
  declarations: [
    GetMapValuePipe
  ],
  imports: [
    CommonModule
  ],
  exports: [
    GetMapValuePipe
  ]
})
export class SharedModule { }
