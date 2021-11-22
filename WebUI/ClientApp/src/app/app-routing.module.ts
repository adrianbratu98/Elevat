import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './features/admin/admin/admin.component';
import { AuthComponent } from './features/auth/auth/auth.component';
import { HomeComponent } from './features/home/home/home.component';


const routes: Routes = [
  { path: 'home', component: HomeComponent},
  { path: 'auth', component: AuthComponent},
  { path: 'admin', component: AdminComponent},
  { path: '', pathMatch: 'full', redirectTo: 'home'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
