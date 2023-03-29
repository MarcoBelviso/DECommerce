import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import {  ActivatedRoute, Route, Router, RouterLink } from '@angular/router';
import { Observable } from 'rxjs';

import { AuthService } from 'src/app/services/auth.service';
import { DecommerceApiService } from 'src/app/services/decommerce-api.service';
import { UserService } from 'src/app/services/user.service';
import { NavbarComponent } from '../../navbar/navbar/navbar.component';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {



  loginForm : FormGroup

  constructor(private AuthService : AuthService, private router:Router, private DEC : DecommerceApiService, private route:ActivatedRoute, private nav : NavbarComponent,
    private service: DecommerceApiService) { }




  onSubmit(){

    this.AuthService.login(this.loginForm.value.username, this.loginForm.value.password)
    .subscribe(
      (response) => {
        this.AuthService.setRole(response.roleId); console.log(response.roleId)
        this.AuthService.setToken(response.token); console.log(response.token)
        this.DEC.getUserId(response.id); console.log(response.id);


        const userId = response.id
        const role = response.roleId;
        if (role == '1') {
          this.router.navigate([`/admin/${userId}`]);
        } else {
          this.router.navigate([`/customer/${userId}`]);
        }

      }
    );

  }


  initForm(){
    this.loginForm = new FormGroup ({
      username:new FormControl(null,Validators.required),
      password:new FormControl(null,Validators.required)
    })
  }

  userId : string|null

  ngOnInit(): void {
    this.initForm()
    this.userId = this.route.snapshot.paramMap.get('id');
  }

  showPassword : boolean

  toggleShowPassword() {
    this.showPassword = !this.showPassword;
  }

  toggleLogin(){
    this.nav.isLogged = !this.nav.isLogged
    this.nav.admin = !this.nav.admin
    this.nav.customer = !this.nav.customer

  }

  onClick(){
    this.nav.admin = true
  }




}




