import { Component, OnDestroy, OnInit } from '@angular/core';
import { EmployeeDTO } from 'src/app/core/models/Dto/employee-dto';
import { ManageEmployeesService } from 'src/app/core/services/manage-employees.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-manage-employees',
  templateUrl: './manage-employees.component.html',
  styleUrls: ['./manage-employees.component.css']
})
export class ManageEmployeesComponent implements OnInit, OnDestroy {


  employees:EmployeeDTO[] = [];
  private getListSubs: Subscription | undefined;  

  constructor(private manageEmployeesService: ManageEmployeesService) { }

  ngOnInit(): void {
    this.getList()
  }
    
  ngOnDestroy(): void {
    this.getListSubs?.unsubscribe();
  }

  getList(){
    this.getListSubs = this.manageEmployeesService.getList().subscribe(
      (res) => {
        this.employees = res;
      },
      (err) => {
        console.log(err);
      }
    );
  }
}
