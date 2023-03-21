import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DecommerceApiService } from './decommerce-api.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http : HttpClient, private DECommerceApiService : DecommerceApiService ) {}



  public setRole(role : string) {
    localStorage.setItem('role', role);
  }

  public getRole() {
    return JSON.parse((localStorage.getItem('role')!));
  }

  public setToken(jwtToken: string) {
    localStorage.setItem('token', jwtToken);
  }

  public getToken(): string {
    return localStorage.getItem('token')!;
  }

  public clear() {
    localStorage.clear();
  }

  login(username : string, password : string): Observable<any> {
    const data = {username : username, password : password}
    return this.http.post(this.DECommerceApiService.DECommerceApiUrl + '/Auth/login' , data)
  }


  //----------------------------------------------------------//

  public isLoggedIn(){
    return this.getRole() && this.getToken()
  }



}
