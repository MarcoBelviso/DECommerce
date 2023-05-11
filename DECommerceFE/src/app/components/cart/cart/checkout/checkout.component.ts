import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Products } from 'src/app/models/products/products';
import { DecommerceApiService } from 'src/app/services/decommerce-api.service';
import { CartComponent } from '../cart.component';
import { Orders } from 'src/app/models/Orders';
import { AuthService } from 'src/app/services/auth.service';
import { OrdersDetails } from 'src/app/models/OrderDetails';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css'],
  providers: [CartComponent]

})
export class CheckoutComponent implements OnInit {

  private readonly key = 'cart';
  cart: Products[] = [];

  constructor(private service:DecommerceApiService, readonly cartComponent : CartComponent, private authService: AuthService) { }

  ngOnInit(): void {
    this.cart = this.getCartProducts();
    this.calculateTotal()
  }

  private getCartProducts(): Products[] {
    const storedProducts = localStorage.getItem(this.key);
    if (storedProducts) {
      console.log(storedProducts)
      return JSON.parse(storedProducts);

    } else {
      return [];
    }

  }

 checkForm : FormGroup

  cartItems: any[] = JSON.parse(localStorage.getItem('cart') || '[]');
  total: number = 0;

  calculateTotal() {
    for (let i = 0; i < this.cartItems.length; i++) {
      this.total += this.cartItems[i].unitPrice;
    }
    console.log(this.total)
  }

  @Input()
  email: string
  address: string
  country:string
  state:string
  cap:number


  onCheckout(){
    const order = new Orders
    order.userId = this.authService.getUserID()
    order.totalPrice
    order.field1
    order.field2
    order.field3
    order.field4
    order.field5
    order.field6
    order.field7
    order.field8


    const orderDetails = this.getCartProducts().map( item => {
      const detail = new OrdersDetails
      detail.productID = item.productID;
      console.log(detail.productID)
      return detail

    })
    this.service.checkout(order, orderDetails).subscribe()
  }

  loading = false;
  success = false;

  acquisto() {
    // Mostra il modal di caricamento
    this.loading = true;

    // Simula un caricamento di 5 secondi
    setTimeout(() => {
      // Nasconde il modal di caricamento
      this.loading = false;

      // Mostra il modal di conferma acquisto
      this.success = true;
    }, 5000);
  }


}
