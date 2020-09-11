import { Injectable } from '@angular/core';
import { RepositoryService } from './repository.service';
import { MenuItem } from 'src/app/_interfaces/menuItem.model';
import { LoaderService } from './loader.service';
import { BehaviorSubject } from 'rxjs';
import { Order } from 'src/app/_interfaces/order.model';
import { OrderLine } from 'src/app/_interfaces/orderLine.model';
import { Menu } from 'src/app/_interfaces/menu.model';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  menuItems: MenuItem[];
  order: Order[];
  orderLine: OrderLine[];
  menu:Menu;
  

  private cart: MenuItem[] = [];
  private cartItemCount = new BehaviorSubject(0);

  constructor(private repository:RepositoryService, private ionLoader: LoaderService) { }

  showLoader() {
    this.ionLoader.showLoader();

    setTimeout(() => {
      this.hideLoader();
    }, 2000);
  }

  hideLoader() {
    this.ionLoader.hideLoader();
  }

  getAllMenuItems = () =>{
    let apiAddress: string = "api/menuItem";
    this.showLoader();
    this.repository.getData(apiAddress)
      .subscribe(res => {
        this.menuItems = res as MenuItem[];
        this.hideLoader();
      })
  }

  getCart(){
    return this.cart;
  }

  getCartItemCount() {
    return this.cartItemCount;
  }

  removeCartItemCount(){
    return this.cartItemCount.next(0);
  }

  addMenuItem(menuItem) {
    let added = false;
    for (let p of this.cart) {
      if (p.menuItemId === menuItem.menuItemId) //this is wrong
      {
        p.menuItemAmount += 1;
        added = true;
        break;
      }
    }
    if (!added) {
      menuItem.menuItemAmount = 1;
      this.cart.push(menuItem);
      console.log("added");
      console.log(this.cart);      
    }
    
    this.cartItemCount.next(this.cartItemCount.value + 1);
  }

  decreaseMenuItem(menuItem) {
    for (let [index, p] of this.cart.entries()) {
      if (p.menuItemId === menuItem.menuItemId) {
        p.menuItemAmount -= 1;
        if (p.menuItemAmount == 0) {
          this.cart.splice(index, 1);
        }
      }
    }
    this.cartItemCount.next(this.cartItemCount.value - 1);
  }

  removeMenuItem(menuItem) {
    for (let [index, p] of this.cart.entries()) {
      if (p.menuItemId === menuItem.menuItemId) {
        this.cartItemCount.next(this.cartItemCount.value - p.menuItemAmount);
        this.cart.splice(index, 1);
        console.log(p.menuItemAmount);
      }
    }
  }

  /*createOrder(order){
    this.repository.create(order)
  }*/
}
