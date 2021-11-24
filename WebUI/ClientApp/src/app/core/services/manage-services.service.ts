import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpEndpoints } from '../models/App/http-endpoints';
import { HttpMethod } from '../models/App/http-methods';
import { SearchServiceDTO } from '../models/Dto/search-service-dto';
import { ServiceDTO } from '../models/Dto/service-dto';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class ManageServicesService {

  constructor(private httpService: HttpService) { }

  getList(serviceFilterModel: SearchServiceDTO) : Observable<ServiceDTO[]> {
    return this.httpService.makeHttpCall(HttpEndpoints.GetAllServices, HttpMethod.POST, serviceFilterModel);
  }

  create(serviceModel: ServiceDTO) : Observable<number> {
    return this.httpService.makeHttpCall(HttpEndpoints.CreateNewService, HttpMethod.POST, serviceModel)
  }

  update(serviceModel: ServiceDTO) : Observable<number> {
    return this.httpService.makeHttpCall(HttpEndpoints.UpdateService, HttpMethod.PUT, serviceModel)
  }

  delete(id: number) : Observable<any> {
    return this.httpService.makeHttpCall(HttpEndpoints.DeleteService, HttpMethod.DELETE, id)
  }
}
