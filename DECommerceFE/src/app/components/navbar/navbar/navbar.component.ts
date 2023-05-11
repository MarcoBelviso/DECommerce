import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { DecommerceApiService } from 'src/app/services/decommerce-api.service';
import { LoginComponent } from '../../log-reg/login/login.component';
import { AdminComponent } from '../../users/admin/admin.component';
import { CustomerComponent } from '../../users/customer/customer.component';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private AuthService : AuthService, private userService:DecommerceApiService, private route:ActivatedRoute,public userAuthService: AuthService) { }



  id:string

  ngOnInit(): void {
    this.id =this.AuthService.getUser();
    this.AuthService.setUser(this.id)


  }

  isAuthenticated(){
    return this.AuthService.isLoggedIn()
  }


  onLogOut(){
    this.AuthService.logOut();
  }





}
