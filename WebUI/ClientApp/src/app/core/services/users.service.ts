import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpEndpoints } from '../models/App/http-endpoints';
import { HttpMethod } from '../models/App/http-methods';
import { AccountListDto } from '../models/Dto/account-list-dto';
import { EmployeeDTO } from '../models/Dto/employee-dto';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private httpService: HttpService) { }

  getList() : Observable<AccountListDto[]> {
    return this.httpService.makeHttpCall(HttpEndpoints.GetUserList, HttpMethod.GET)
  }
}
