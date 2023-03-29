import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DecommerceApiService {
  readonly DECommerceApiUrl = 'https://localhost:7065/api';

  constructor(private http: HttpClient, private router: Router) {}

  addUsers(user: any) {
    return this.http.post(this.DECommerceApiUrl + '/users', user);
  }

  getUserId(id: number | string) {
    return this.http.get(this.DECommerceApiUrl + `/users/${id}`);
  }

  CreateProducts(data: any) {
    return this.http.post(this.DECommerceApiUrl + '/products', data);
  }

  uploadImage(image: string): Observable<Response> {
    const formData = new FormData();

     formData.append('image/*', image);

    return this.http.post<Response>(this.DECommerceApiUrl +'/products', formData);
  }

  getProducts():Observable<any[]> {
    return this.http.get<any>(this.DECommerceApiUrl + '/products');
  }

  getProduct(id:string): Observable<any>{
    return this.http.get(this.DECommerceApiUrl + `/products/${id}`);
  }

  getProductById(productId:any): Observable<any[]>{
    return this.http.get<any>(this.DECommerceApiUrl + `/products/${productId}`);
  }

  createCategory(data : any): Observable<any>{
    return this.http.post(this.DECommerceApiUrl + '/productCategories', data);
  }

  getCategory():Observable<any>{
    return this.http.get(this.DECommerceApiUrl + '/productCategories');
  }

}
