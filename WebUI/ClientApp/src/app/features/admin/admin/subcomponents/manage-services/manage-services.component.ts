import { HttpClient } from '@angular/common/http';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ServiceFilterModel } from 'src/app/core/models/ServiceFilterModel';
import { ServiceModel } from 'src/app/core/models/ServiceModel';
import { ServiceSaloonService } from 'src/app/core/services/service.service';

@Component({
  selector: 'app-manage-services',
  templateUrl: './manage-services.component.html',
  styleUrls: ['./manage-services.component.css']
})
export class ManageServicesComponent implements OnInit, OnDestroy {

  services: ServiceModel[] = [];

  private serviceFilterModel: ServiceFilterModel  = new ServiceFilterModel(); 
  private getAllServicesSubs: Subscription | undefined;  
  private sortColumn: string = "Name";
  private sortAscending: boolean = true;
  nameFilter: string = "";
  workServiceModel:ServiceModel | undefined;



  constructor(private serviceSaloon: ServiceSaloonService) { }

  ngOnInit(): void {
    this.getAllServices();
  }

  ngOnDestroy(): void {
    if(!this.getAllServicesSubs?.closed) 
      this.getAllServicesSubs?.unsubscribe();
  }

  getAllServices() {
    if(this.getAllServicesSubs && !this.getAllServicesSubs?.closed) 
      this.getAllServicesSubs?.unsubscribe();
    this.serviceFilterModel = {
      sortColumn: this.sortColumn,
      sortAscending: this.sortAscending,
      nameFilter: this.nameFilter
    }
    this.getAllServicesSubs = this.serviceSaloon.getAllServices(this.serviceFilterModel).subscribe(
      res => {
        this.services = res;
      },
      err => {
        console.log(err);
      }
    )
  }

  sortService(sortColumn: string) {
      this.sortAscending = !this.sortAscending;
      this.sortColumn = sortColumn;
      this.getAllServices();
  }

  addServiceRow() {
    if(!this.workServiceModel){
      this.services.push(this.workServiceModel = { id: 0, name: '', minutes: 0, price: 0 });
      setTimeout(()=>{ 
        document.getElementById('focusInput')?.focus();
      }, 0);
    }      
  }

  editServiceRow(service: ServiceModel) {
    if(!this.workServiceModel) {
      this.workServiceModel = {
        id: service.id,
        name: service.name,
        minutes: service.minutes,
        price: service.price
      }
      setTimeout(()=>{ 
        document.getElementById('focusInput')?.focus();
      },0); 
    }      
  }

  cancel(service:ServiceModel) {
    if(this.workServiceModel) {
      service.id = this.workServiceModel.id;
      service.name = this.workServiceModel.name;
      service.minutes = this.workServiceModel.minutes;
      service.price = this.workServiceModel.price;
    }
    this.services = this.services.filter(service => service.id != 0);
    this.workServiceModel = undefined;
  }

  saveService(service: ServiceModel) {
    if(service.id == 0) {
      this.serviceSaloon.createNewService(service).subscribe(
        (id) => {
          service.id = id;
        });
    }
    else {
      this.serviceSaloon.updateService(service).subscribe(
        () => {
        }
      );
    }
    this.workServiceModel = undefined;
  }

  deleteService(serviceId: number) {
    this.serviceSaloon.deleteService(serviceId).subscribe(
      () => {
        this.services = this.services.filter(sv => sv.id != serviceId);
      },
      err => {
        console.log(err)
      }
    )
  }
}
