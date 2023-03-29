import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { AdminComponent } from '../../users/admin/admin.component';
import { CustomerComponent } from '../../users/customer/customer.component';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private AuthService : AuthService) { }

  admin : boolean
  customer: boolean


  isLogged : boolean


  ngOnInit(): void {
  }


  onLogOut(){
    this.AuthService.logOut();
    this.isLogged = false

    var roleId = this.AuthService.getRole()

    if(this.admin == roleId && roleId == '1'){
      return false
    }
     else if (this.customer == roleId && roleId == '2'){
       return true
     }
    return
  }

onClick(){
  this.customer = false
}

}
