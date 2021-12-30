import { Component, OnInit } from '@angular/core';
import { ShoppingcartserviceService } from '../../services/shoppingcartservice.service';
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  constructor(public service: ShoppingcartserviceService,
    private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.service.getCartInfo();
  }
  getTotal()
  {
    return this.service.listCart.reduce((acc, prod) => acc+= Number(prod.price) * Number(prod.quantity) ,0);
  }
  deleteCart(productId: number){
    this.service.deleteCart(productId);
  }
  goToProducts(){
    this.router.navigate(['product']);
  }
}
