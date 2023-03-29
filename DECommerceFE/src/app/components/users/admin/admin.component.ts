import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { DecommerceApiService } from 'src/app/services/decommerce-api.service';
import { CategoryComponent } from '../../category/category/category.component';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  categoryComponent = CategoryComponent;


  constructor(private route :ActivatedRoute) { }

  activateAddCategoryComponent: boolean = false;
  category: any;




  ngOnInit(): void {

  }




}
