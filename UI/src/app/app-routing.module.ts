import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductDetailsComponent } from './components/shopping-cart/product-list/product-details/product-details.component';
import { CheckoutComponent } from './components/shopping-cart/checkout/checkout.component';
import { ProductListComponent } from './components/shopping-cart/product-list/product-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'product', pathMatch: 'full' },

  { path: 'product', component: ProductListComponent  },
  { path: 'details/:id', component: ProductDetailsComponent },
  { path: 'checkout', component: CheckoutComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
