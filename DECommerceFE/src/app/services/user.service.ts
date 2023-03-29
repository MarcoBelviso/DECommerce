import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { DecommerceApiService } from './decommerce-api.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpclient: HttpClient, private AuthService: AuthService, private DEC : DecommerceApiService) { }


}
