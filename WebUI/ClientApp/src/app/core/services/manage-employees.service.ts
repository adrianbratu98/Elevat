import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpEndpoints } from '../models/App/http-endpoints';
import { HttpMethod } from '../models/App/http-methods';
import { EmployeeDTO } from '../models/Dto/employee-dto';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class ManageEmployeesService {

  constructor(private httpService: HttpService) { }

  getList() : Observable<EmployeeDTO[]> {
    return this.httpService.makeHttpCall(HttpEndpoints.GetAllEmployees, HttpMethod.GET);
  }

}
