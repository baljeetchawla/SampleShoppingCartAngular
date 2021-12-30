import { Component, OnInit } from '@angular/core';
import { ShoppingcartserviceService } from '../../../services/shoppingcartservice.service';
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  constructor(public service: ShoppingcartserviceService,
    private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.service.getProductById(Number(this.route.snapshot.params.id));
  }
  goBack(){
    this.router.navigate(['product']);
  }
  addToCart(productId: any){
    this.service.addToCart(productId);
    
  }
}
