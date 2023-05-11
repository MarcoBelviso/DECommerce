import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Products } from 'src/app/models/products/products';
import { DecommerceApiService } from 'src/app/services/decommerce-api.service';
import { CartComponent } from '../../cart/cart/cart.component';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css'],
  providers: [CartComponent]

})
export class ProductDetailComponent implements OnInit {

  constructor(private route:ActivatedRoute, private service:DecommerceApiService, readonly cartComponent:CartComponent, private router:Router) { }



  product:any
  productId = this.route.snapshot.paramMap.get('id')

  ngOnInit(): void {
    this.service.getProductByProductID(this.productId).subscribe((productData)=>{
      this.product = productData;
      console.log(productData)

    })
    console.log(this.productId)
  }
  ngOnInit1(){
    this.service.getProducts().subscribe( (data:any) => {

      this.product = Object.keys(data).map((key) => {
        data[key] ['id'] = key //a data key aggiungi una proprietà che si chiama id, che è uguale a key
        return data[key]})
    } )
  }

  user:any;
  activateAddUserComponent:boolean = false;


  }


