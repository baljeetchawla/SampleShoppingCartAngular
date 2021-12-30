import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { NavComponent } from './components/shared/nav/nav.component';
import { ShoppingCartComponent } from './components/shopping-cart/shopping-cart.component';
import { ProductListComponent } from './components/shopping-cart/product-list/product-list.component';
import { CheckoutComponent } from './components/shopping-cart/checkout/checkout.component';
import { ProductDetailsComponent } from './components/shopping-cart/product-list/product-details/product-details.component';
//import { ShoppingcartserviceService } from './components/services/shoppingcartservice.service';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    NavComponent,
    ShoppingCartComponent,
    ProductListComponent,
    CheckoutComponent,
    ProductDetailsComponent
    //ShoppingcartserviceService
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule {
  
 }
