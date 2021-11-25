import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { SearchServiceDTO } from 'src/app/core/models/Dto/search-service-dto';
import { ServiceDTO } from 'src/app/core/models/Dto/service-dto';
import { ManageServicesService } from 'src/app/core/services/manage-services.service';

@Component({
  selector: 'app-manage-services',
  templateUrl: './manage-services.component.html',
  styleUrls: ['./manage-services.component.css']
})
export class ManageServicesComponent implements OnInit, OnDestroy {

  services: ServiceDTO[] = [];
  private getListSubs: Subscription | undefined;  
  private sortColumn: string = "Name";
  private sortAscending: boolean = true;
  nameFilter: string = "";
  workService: ServiceDTO | undefined;

  constructor(private manageServicesService: ManageServicesService) { }

  ngOnInit(): void {
    this.getList();
  }

  ngOnDestroy(): void {
    if(!this.getListSubs?.closed) 
      this.getListSubs?.unsubscribe();
  }

  getList() {
    if(this.getListSubs && !this.getListSubs?.closed) 
      this.getListSubs?.unsubscribe();
    const searchDTO = <SearchServiceDTO>{
      sortColumn: this.sortColumn,
      sortAscending: this.sortAscending,
      nameFilter: this.nameFilter
    }
    this.getListSubs = this.manageServicesService.getList(searchDTO).subscribe(
      (res) => {
        this.services = res;
      },
      (err) => {
        console.log(err);
      }
    )
  }

  addRow() {
      this.services = this.services.filter(service => service.id != 0);
      this.workService = { id: 0, name: '', minutes: 0, price: 0 };
      this.services.push({ id: 0, name: '', minutes: 0, price: 0 });
      setTimeout(()=>{ 
        document.getElementById('focusInput')?.focus();
      }, 0);   
  }

  editRow(service: ServiceDTO) {
    this.services = this.services.filter(service => service.id != 0);
      this.workService = {
        id: service.id,
        name: service.name,
        minutes: service.minutes,
        price: service.price
      }
      setTimeout(()=>{ 
        document.getElementById('focusInput')?.focus();
      },0); 
  }

  cancel() {
    this.services = this.services.filter(service => service.id != 0);
    this.workService = undefined;
  }

  save() {
    if(this.workService) {
      const action = this.workService?.id == 0 ?
        this.manageServicesService.create(this.workService) :
        this.manageServicesService.update(this.workService);
      action.subscribe(
        (serviceId) => {
          let service = this.services.find(service => service.id == this.workService?.id);
          if(service) {
            service.id = serviceId;
            service.name = this.workService ? this.workService.name : "",
            service.minutes = this.workService ? this.workService.minutes : 0,
            service.price = this.workService ? this.workService.price : 0
          }
          this.workService = undefined;
        })
    }
  }

  delete(serviceId: number) {
    this.manageServicesService.delete(serviceId).subscribe(
      (_) => {
        this.services = this.services.filter(sv => sv.id != serviceId);
      },
      (err) => {
        console.log(err)
      }
    )
  }

  sort(sortColumn: string) {
    this.sortAscending = !this.sortAscending;
    this.sortColumn = sortColumn;
    this.getList();
  }
}
