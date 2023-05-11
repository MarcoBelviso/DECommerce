import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { DecommerceApiService } from 'src/app/services/decommerce-api.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(private userService:DecommerceApiService, private route: ActivatedRoute, private authService : AuthService) { }

  user : any
  isPasswordHidden = true;

  togglePassword(): void {
    this.isPasswordHidden = !this.isPasswordHidden;
  }

  ngOnInit(): void {
    //prendo dal local storage lo userid e lo uso come imput per caricarmi tutti i dati dello user
    this.userService.getUser(this.authService.getUserID()).subscribe((userData)=>{
      this.user = userData;
      console.log(userData)
    })



  }




  OnGetUser(){

  }


  }



