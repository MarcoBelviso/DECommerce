import { Component, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { DecommerceApiService } from 'src/app/services/decommerce-api.service';
import { Catalog } from 'src/app/models/catalog/catalog';
import { Products } from 'src/app/models/products/products';


@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.css']
})
export class CatalogComponent implements OnInit {

  product! : Products



    @Output() products:any
    productId: string
    unitPrice:number
    image:string
    field1: string
    field2:string
  constructor(private productService : DecommerceApiService, private route: ActivatedRoute) { }

  ngOnInit(): void {

    this.productService.getProducts().subscribe( (data:any) => {
      this.product = data
      console.log(data)
    // this.products = Object.keys(data).map((key) => {
    //   data[key] ['id'] = key
    //   return data[key]})
  } )

}

}

