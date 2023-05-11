import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Products } from 'src/app/models/products/products';
import { DecommerceApiService } from 'src/app/services/decommerce-api.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  constructor(private DecommerceApiService : DecommerceApiService ,  readonly route : ActivatedRoute) { }

  private key = 'cart';

  products = Products;
  cartItems: any  = JSON.parse(localStorage.getItem('cart') || '[]');




ngOnInit(): void {
  const productId = this.route.snapshot.params[('id')]; // get the id parameter from the URL
  this.DecommerceApiService.getProductById(productId).subscribe(products => {
    this.cartItems.push(productId);
    console.log(products)
    this.cartItems = this.getCartProducts();
  });
}
getCartProducts(): Products[] {
  const storedProducts = localStorage.getItem(this.key);
  if (storedProducts) {
    return JSON.parse(storedProducts);
  } else {
    return [];
  }
}

saveCartProducts(cartProducts: Products[]): void {
  localStorage.setItem(this.key, JSON.stringify(cartProducts));
}

addToCart(product: Products): void {
  const cartProducts = this.getCartProducts();
  cartProducts.push(product);

        this.saveCartProducts(cartProducts);
}

removeFromCart(product: Products): void {
let cartProducts = this.getCartProducts();
  cartProducts = cartProducts.filter(p => p !== product);
  this.saveCartProducts(cartProducts);
}

//metodo da richiamare per aggiornare la variabile cartItems del componente
loadCartItems(){
  this.cartItems = JSON.parse(localStorage.getItem('cart') || '[]');
}
//metodo per rimuovere un elemento dal carrello, prende come parametro l'indice dell'elemento che si desidera rimuovere dall'array del carrello.
removeItem(index: number) {
  this.cartItems.splice(index, 1);
  localStorage.setItem('cart', JSON.stringify(this.cartItems));
  this.loadCartItems();
  this.calculateTotal();
}


removeAllItems() {
  localStorage.removeItem('cart');
  this.loadCartItems();
  this.calculateTotal();
}

//metodo che serve per calcolare il totale, richiamicamo questo metodo ogni volta che rimuoviamo un oggetto dal carrello e nell' ngOnInit del checkoutComponent
//metodo che ritorna un valore intero che sarebbe il totale
calculateTotal() {
  let total = 0;
  for (let i = 0; i < this.cartItems.length; i++) {
    total += this.cartItems[i].unitPrice;
  }
  return total
}

}


