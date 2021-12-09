import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin/admin.component';
import { ManageServicesComponent } from './admin/subcomponents/manage-services/manage-services.component';
import { DashboardComponent } from './admin/subcomponents/dashboard/dashboard.component';
import { SidebarComponent } from './admin/subcomponents/sidebar/sidebar.component';
import { ManageUsersComponent } from './admin/subcomponents/manage-users/manage-users.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';



@NgModule({
  declarations: [
    AdminComponent,
    ManageServicesComponent,
    DashboardComponent,
    SidebarComponent,
    ManageUsersComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    SharedModule
  ]
})
export class AdminModule { }
