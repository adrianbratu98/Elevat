import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthComponent } from './auth/auth.component';
import { RegisterComponent } from './auth/subcomponents/register/register.component';
import { LoginComponent } from './auth/subcomponents/login/login.component';



@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    AuthComponent
  ],
  imports: [
    CommonModule
  ]
})
export class AuthModule { }
