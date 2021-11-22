import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  @Input() selectedChild: string = ""
  @Output() tabSelected: EventEmitter<string> = new EventEmitter<string>();

  constructor() { }

  ngOnInit(): void {
  }

  selectDashboard(){
    this.tabSelected.emit("dashboard")
    this.selectedChild = "dashboard"
  }

  selectManageServices(){
    this.tabSelected.emit("manage-services")
    this.selectedChild = "manage-services"
  }

  selectManageEmployees(){
    this.tabSelected.emit("manage-employees")
    this.selectedChild = "manage-employees"
  }

}
