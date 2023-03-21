import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/log-reg/login/login.component';
import { RegisterComponent } from './components/log-reg/register/register.component';
import { AdminComponent } from './components/users/admin/admin.component';
import { CustomerComponent } from './components/users/customer/customer.component';
import { AuthAdminGuard } from './guard/auth-admin.guard';
import { AuthCustomerGuard } from './guard/auth-customer.guard';
import { AuthGuard } from './guard/auth.guard';
import { HomeComponent } from './home/home/home.component';


const routes: Routes = [
  {path: '' , pathMatch: 'full', redirectTo: 'home'},
  {path: 'home', component : HomeComponent},
  {path: 'login', component : LoginComponent},
  {path: 'customer/:id', component : CustomerComponent, canActivate: [AuthGuard, AuthCustomerGuard]},
  {path: 'admin/:id', component : AdminComponent, canActivate: [AuthGuard, AuthAdminGuard]},
  {path: 'register', component : RegisterComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
