import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProductModel } from '../model/product.model';

@Injectable({
  providedIn: 'root'
})
export class ShoppingcartserviceService {

  constructor(private http: HttpClient) { }
readonly baseUrl ='http://localhost:61964/api/ShoppingCart';
listProducts: any[];
listCart: any[];
showCartCount: number;
cartCount: number;
productDetails: ProductModel;
  getProductsList(): any{
    this.http.get<any>(this.baseUrl+'/GetProducts').subscribe(data => {
      this.listProducts = data.value;
    })        
  }

  getCartInfo(): any{
    this.http.get<any>(this.baseUrl+'/Checkout').subscribe(data => {
      this.listCart = data.value;
      this.showCartCount = this.listCart == undefined ? 0 : this.listCart.length;
    })        
  }

  getProductById(productId: number): any{
    this.http.get<any>(this.baseUrl+'/GetProductByID?id='+ productId).subscribe(data => {
      this.productDetails = data.value;
    })        
  }
  addToCart(productId: number): any{
    this.http.post(this.baseUrl+'/AddToCart?id='+productId, productId).subscribe(data => {
   this.getCartCount();
    })        
  }
 deleteCart(productId: number): any{
  this.http.post(this.baseUrl+'/DeleteCart?id='+productId, productId).subscribe(data => {
  })  }

  getCartCount(): any{
    this.http.get<any>(this.baseUrl+'/getCartCount').subscribe(data => {
      this.cartCount = data.value;
    })        
}
}
