import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DecommerceApiService } from 'src/app/services/decommerce-api.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private decommerceService : DecommerceApiService, private router:Router) { }

  ngOnInit(): void {

  }

  @Input() user: any;
  id:number
  name:string="";
  surname:string="";
  username:string="";
  password:string="";
  birthdate:Date | undefined;
  homeform : FormGroup








  addUser(){
    var user = {
      name:this.name,
      surname:this.surname,
      UserName:this.username,
      password:this.password,
      Field3:this.birthdate,

    }
    this.decommerceService.addUsers(user).subscribe(res => {
      this.router.navigate(['/login'])
  }

    )}
}



