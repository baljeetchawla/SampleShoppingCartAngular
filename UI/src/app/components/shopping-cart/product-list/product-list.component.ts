import { Component, OnInit } from '@angular/core';
import { ShoppingcartserviceService } from '../../services/shoppingcartservice.service';
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  productsArray: any;
  constructor(public service: ShoppingcartserviceService,
    private router: Router, private route: ActivatedRoute) {
 }

  ngOnInit(): void {
     this.service.getProductsList();
  }
  productDetails(productId: any){
      this.router.navigate(['details/', productId]);
  }
  addToCart(productId: any){
    this.service.addToCart(productId);
 
  }
}
