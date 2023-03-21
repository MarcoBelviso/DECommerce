import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DecommerceApiService {

  readonly DECommerceApiUrl = "https://localhost:7065/api"

  constructor(private http : HttpClient, private router : Router) { }

  addUsers(user : any){
    return this.http.post(this.DECommerceApiUrl + '/users', user);
  }

  getUserId(id:number|string){
    return this.http.get(this.DECommerceApiUrl + `/users/${id}`).pipe(
      map((response: any) => {
        const userId = response.userId;
        if(response.roleId == '2'){
        this.router.navigate(['/customer', userId]);
      } else {
        this.router.navigate(['/admin', userId]);
      }
        return id;
      })
    );;



  // getUserInfo(token: string): Observable<any> {
  //   const headers = new HttpHeaders({
  //   'Authorization': 'Bearer ' + token
  //   });
  //   return this.http.get<any>(this.DECommerceApiUrl + '/auth/login', {headers: headers });
  //   }

  }

}
