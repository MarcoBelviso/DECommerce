import { Component, Input, OnInit } from '@angular/core';
import { DecommerceApiService } from 'src/app/services/decommerce-api.service';
import { Products } from 'src/app/models/products/products';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  product: Products = new Products();
  selectedFile!: File

  constructor(private service : DecommerceApiService) { }


  addProductForm : FormGroup;
  categoryList$: Observable<any>;
  selectedCategory: string;
  selectedCategoryId: string;

ngOnInit(): void {
  this.categoryList$ = this.service.getCategory();
  console.log(this.categoryList$)

  this.addProductForm = new FormGroup({
    selectedCategoryFormControl : new FormControl(null, Validators.required),
    unitPriceFormControl : new FormControl(null, Validators.required),
    imageFormControl : new FormControl(null, Validators.required),
    field1FormControl : new FormControl(null, Validators.required),
    field2FormControl : new FormControl(null, Validators.required),
  })
}

onSelectCategory(event: Event) {
  const target = event.target as HTMLSelectElement;
  this.product.productCategoriesId =  target.value;
}

onFileSelected(event:any) {
  this.selectedFile = <File>event.target.files[0];
}

onAddProduct() {


  const fd = new FormData();
  fd.append('image', this.selectedFile, this.selectedFile.name);
  fd.append('productCategoriesId', this.product.productCategoriesId);
  fd.append('unitPrice', this.product.unitPrice);
  fd.append('field1', this.product.field1);
  fd.append('field2', this.product.field2);


  this.service.CreateProducts(fd).subscribe(
    response => console.log(response),
    error => console.log(error)
  );
}



}
