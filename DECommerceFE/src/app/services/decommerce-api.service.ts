import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { forkJoin, map, Observable, switchMap } from 'rxjs';
import { Orders } from '../models/Orders';
import { OrdersDetails } from '../models/OrderDetails';

@Injectable({
  providedIn: 'root',
})
export class DecommerceApiService {
  readonly DECommerceApiUrl = 'https://localhost:7065/api';

  constructor(private http: HttpClient, private router: Router) {}

  addUsers(user: any) {
    return this.http.post(this.DECommerceApiUrl + '/users', user);
  }

  getUsers():Observable<any[]> {
    return this.http.get<any>(this.DECommerceApiUrl + '/users');
  }

  getUser(userID : any){
    return this.http.get(this.DECommerceApiUrl + '/users/userId'+ userID + '?userId=' + userID);
  }

  getUserId(userId: number | string) {
    return this.http.get(this.DECommerceApiUrl + `/users/${userId}`);
  }

  //----------------------------------------------------------------------------------------//


  uploadImage(image: string): Observable<Response> {
    const formData = new FormData();

     formData.append('image/*', image);

    return this.http.post<Response>(this.DECommerceApiUrl +'/products', formData);
  }

  //---------------------------------------------------------------------------------------//

  CreateProducts(data: any) {
    return this.http.post(this.DECommerceApiUrl + '/products', data);
  }

  getProducts() {
    return this.http.get(this.DECommerceApiUrl + '/products');
  }

  getProduct(id:string): Observable<any>{
    return this.http.get(this.DECommerceApiUrl + `/products/${id}`);
  }

  getProductByProductID(id : any) {
    return this.http.get(this.DECommerceApiUrl + '/products/productId' + id + '?productId=' + id);
  }

  getProductById(id:number|string): Observable<any[]>{
    return this.http.get<any>(this.DECommerceApiUrl + `/products/productid${id}`);
  }

  //------------------------------------------------------------------------------------//

  createCategory(data : any): Observable<any>{
    return this.http.post(this.DECommerceApiUrl + '/productCategories', data);
  }

  getCategory():Observable<any>{
    return this.http.get(this.DECommerceApiUrl + '/productCategories');
  }

  //----------------------------------------------------------------------------------//

  addOrderDetails(data: any){
    return this.http.post(this.DECommerceApiUrl + '/orders', data);
  }

  deleteProduct(productId:any){
    return this.http.delete(this.DECommerceApiUrl + `/products/${productId}`);
  }


  //-------------------------------------------------------------------------------------//
  checkout(order: Orders, orderDetails: OrdersDetails[]): Observable<any> {
    return this.http.post<any>(this.DECommerceApiUrl + '/orders' , order).pipe(
      switchMap(response => {
       console.log(response)
        const orderID = response;
        orderDetails.forEach(detail => detail.orderId = orderID);
        const requests = orderDetails.map(detail => this.http.post<any>(this.DECommerceApiUrl + '/orderDetails', detail));
        return forkJoin(requests);
      })
    );
  }

}
