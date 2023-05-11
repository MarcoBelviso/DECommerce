import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CartComponent } from './components/cart/cart/cart.component';
import { CheckoutComponent } from './components/cart/cart/checkout/checkout.component';
import { CatalogComponent } from './components/catalog/catalog/catalog.component';
import { CategoryComponent } from './components/category/category/category.component';
import { LoginComponent } from './components/log-reg/login/login.component';
import { RegisterComponent } from './components/log-reg/register/register.component';
import { OrderComponent } from './components/orders/order/order.component';
import { ProductDetailComponent } from './components/products/product-detail/product-detail.component';
import { ProductsComponent } from './components/products/products/products.component';
import { AdminComponent } from './components/users/admin/admin.component';
import { CustomerComponent } from './components/users/customer/customer.component';
import { ProfileComponent } from './components/users/customer/profile/profile.component';
import { AuthAdminGuard } from './guard/auth-admin.guard';
import { AuthCustomerGuard } from './guard/auth-customer.guard';
import { AuthGuard } from './guard/auth.guard';
import { HomeComponent } from './home/home/home.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'home' },
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {path: 'productDetail/:id', component: ProductDetailComponent},

  //------------------------Customer-------------------------\\

  {path: 'customer/:id',component: CustomerComponent,
  canActivate: [AuthGuard, AuthCustomerGuard],},

  {path: 'customer/:id/profile', component: ProfileComponent,
  canActivate: [AuthGuard, AuthCustomerGuard]},

  { path: 'customer/:id/cart', component: CartComponent,
  canActivate: [AuthGuard, AuthCustomerGuard]},

  { path: 'customer/:id/checkout', component: CheckoutComponent,
  canActivate: [AuthGuard, AuthCustomerGuard]},

  { path: 'customer/:id/order', component: OrderComponent,
  canActivate: [AuthGuard, AuthCustomerGuard]},

  //-------------------------Admin----------------------------\\

  {path: 'admin/:id',component: AdminComponent,
  canActivate: [AuthGuard, AuthAdminGuard]},

  {path: 'admin/:id/products', component: ProductsComponent,
  canActivate: [AuthGuard, AuthAdminGuard]},

  {path: 'catalog/:id', component: CatalogComponent},

  {path: 'admin/:id/category', component: CategoryComponent,
  canActivate: [AuthGuard, AuthAdminGuard] },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
