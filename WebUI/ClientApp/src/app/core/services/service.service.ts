import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpEndpoints } from '../models/http-endpoints';
import { HttpMethod } from '../models/http-methods';
import { ServiceFilterModel } from '../models/ServiceFilterModel';
import { ServiceModel } from '../models/ServiceModel';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class ServiceSaloonService {

  

  constructor(private httpService: HttpService) { }

  getAllServices(serviceFilterModel: ServiceFilterModel){
    return this.httpService.makeHttpCall(HttpEndpoints.GetAllServices, HttpMethod.POST, serviceFilterModel);
  }

  createNewService(serviceModel: ServiceModel){
    return this.httpService.makeHttpCall(HttpEndpoints.CreateNewService, HttpMethod.POST, serviceModel)
  }

  updateService(serviceModel: ServiceModel){
    return this.httpService.makeHttpCall(HttpEndpoints.UpdateService, HttpMethod.PUT, serviceModel)
  }

  deleteService(id: number){
    return this.httpService.makeHttpCall(HttpEndpoints.DeleteService, HttpMethod.DELETE, id)
  }
}
