import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Products } from 'src/app/models/products/products';
import { ConfigurationService } from 'src/app/services/configuration.service';
import { DecommerceApiService } from 'src/app/services/decommerce-api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private productService : DecommerceApiService, private route: ActivatedRoute,  public configurationService: ConfigurationService) { }

  product! : Products

  nameComponent : string= 'HomeComponent';

  products:any

  ngOnInit(): void {

    this.productService.getProducts().subscribe( (data:any) => {

      this.products = Object.keys(data).map((key) => {
        data[key] ['id'] = key //a data key aggiungi una proprietà che si chiama id, che è uguale a key
        return data[key]})
    } )

}

}
