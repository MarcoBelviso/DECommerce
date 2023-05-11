import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { HomeComponent } from './home/home/home.component';
import { CustomerComponent } from './components/users/customer/customer.component';
import { LoginComponent } from './components/log-reg/login/login.component';
import { RegisterComponent } from './components/log-reg/register/register.component';
import { NavbarComponent } from './components/navbar/navbar/navbar.component';
import { ProductsComponent } from './components/products/products/products.component';
import { CatalogComponent } from './components/catalog/catalog/catalog.component';
import { CartComponent } from './components/cart/cart/cart.component';
import { CategoryComponent } from './components/category/category/category.component';
import { ProfileComponent } from './components/users/customer/profile/profile.component';
import { ProductDetailComponent } from './components/products/product-detail/product-detail.component';
import { CheckoutComponent } from './components/cart/cart/checkout/checkout.component';
import { OrderComponent } from './components/orders/order/order.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CustomerComponent,
    LoginComponent,
    RegisterComponent,
    NavbarComponent,
    ProductsComponent,
    CatalogComponent,
    CartComponent,
    CategoryComponent,
    ProfileComponent,
    ProductDetailComponent,
    CheckoutComponent,
    OrderComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,

  ],
  providers: [

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
