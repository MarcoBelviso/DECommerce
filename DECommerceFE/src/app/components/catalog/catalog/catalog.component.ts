import { Component, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { DecommerceApiService } from 'src/app/services/decommerce-api.service';
import { Catalog } from 'src/app/models/catalog/catalog';
import { Products } from 'src/app/models/products/products';
import { CartComponent } from '../../cart/cart/cart.component';
import { ConfigurationService } from 'src/app/services/configuration.service';
import { AuthService } from 'src/app/services/auth.service';


@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.css'],
})
export class CatalogComponent implements OnInit {

  product! : Products



  products:any

  nameComponent : string= 'CatalogComponent';

    // @Output() products:any
    // productId: string
    // unitPrice:number
    // image:string
    // field1: string
    // field2:string

    productId = this.route.snapshot.paramMap.get('id')

  constructor(private productService : DecommerceApiService, private route: ActivatedRoute, private router: Router, public configurationService: ConfigurationService, public service : AuthService) { }

  ngOnInit(): void {

    this.productService.getProducts().subscribe( (data:any) => {

      this.products = Object.keys(data).map((key) => {
        data[key] ['id'] = key //a data key aggiungi una proprietà che si chiama id, che è uguale a key
        return data[key]})
    } )

    this.productList$ = this.productService.getProducts();


}

productList$! : any;


delete(){
  if(confirm(`Are you sure you want to delete this product?`))
  {
    this.productService.deleteProduct(this.productId).subscribe()
    this.productList$ = this.productService.getProducts();
  }
  this.router.navigate(['/catalog/:id']);
}

}

