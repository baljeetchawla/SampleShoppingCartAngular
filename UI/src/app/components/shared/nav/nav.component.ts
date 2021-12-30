import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import { ShoppingcartserviceService } from '../../services/shoppingcartservice.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private router: Router, private route: ActivatedRoute,
    public service: ShoppingcartserviceService) { }

  ngOnInit(): void {
    this.getCartCount();
  }
  goToCart(){
    this.router.navigate(['checkout']);
  }
  getCartCount()
  {
    this.service.getCartCount();
  }
}
