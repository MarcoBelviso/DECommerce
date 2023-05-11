import { Component, OnInit } from '@angular/core';
import { Products } from 'src/app/models/products/products';
import { DecommerceApiService } from 'src/app/services/decommerce-api.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  constructor(private productService : DecommerceApiService,) { }

  product! : Products

  products:any

  ngOnInit(): void {

    this.productService.getProducts().subscribe( (data:any) => {

      this.products = Object.keys(data).map((key) => {
        data[key] ['id'] = key //a data key aggiungi una proprietà che si chiama id, che è uguale a key
        return data[key]})
    } )

}

}
