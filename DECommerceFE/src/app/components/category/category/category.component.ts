import { Component, Input, OnInit } from '@angular/core';
import { DecommerceApiService } from 'src/app/services/decommerce-api.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  @Input() productCategories:any
  prodductCategoriesId:number
  field1:string

  constructor(private service : DecommerceApiService) { }


  onAddCategory(){
    var productCategories={
      field1:this.field1
    }

    this.service.createCategory(productCategories).subscribe(
      response => console.log(response)
    )
  }


  ngOnInit(): void {


  }




}
