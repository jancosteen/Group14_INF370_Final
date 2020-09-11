import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import {AuthenticationService} from './../../services/authentication.service';
import { LoaderService } from 'src/app/shared/services/loader.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { MenuItem } from 'src/app/_interfaces/menuItem.model';
import { CartService } from 'src/app/shared/services/cart.service';
import { BehaviorSubject } from 'rxjs';
import { ModalController, AlertController, NavController } from '@ionic/angular';
import { CartModalPage } from 'src/app/cart/cart-modal/cart-modal.page';
import { ActivatedRoute } from '@angular/router';
import { Menu } from 'src/app/_interfaces/menu.model';
import { MenuItemPrice } from 'src/app/_interfaces/menuItemPrice.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';


@Component({
  selector: 'app-menu',
  templateUrl: './menu.page.html',
  styleUrls: ['./menu.page.scss'],
})
export class MenuPage implements OnInit {
  menuItemDetails: MenuItem[];
  menuItem: MenuItem[];
  menuItemPrice: MenuItemPrice[];
  public menu: Menu;
  public errorMessage: string = '';
  
  cart=[];
  cartItemCount: BehaviorSubject<number>;

  @ViewChild('cart', {static: false, read: ElementRef})fab: ElementRef;

  constructor(private alertCtrl: AlertController, private modalCtrl: ModalController,
    private cartService: CartService ,private authService: AuthenticationService, 
    private ionLoader: LoaderService, private repository:RepositoryService,
    private activeRoute: ActivatedRoute,
    private toast: MatSnackBar,
    private nav: NavController,
    private errorHandler: ErrorHandlerService) { }

  ngOnInit() { 
    this.getMenuItems();   
    this.cart = this.cartService.getCart();
    this.cartItemCount = this.cartService.getCartItemCount();    
  }


  showLoader() {
    this.ionLoader.showLoader();

    setTimeout(() => {
      this.hideLoader();
    }, 2000);
  }

  hideLoader() {
    this.ionLoader.hideLoader();
  }  

  setCartToZero(){
    this.cart = [];
  }

  getMenuItems(){
    let id: string = this.activeRoute.snapshot.params['id'];
    let apiUrl: string = `api/menu/${id}/res`
    this.showLoader();
    this.repository.getData(apiUrl)
      .subscribe(res=>{
        this.hideLoader();
        this.menu = res as Menu;
        this.menuItemDetails = this.menu.menuItem;
        this.menuItemPrice = this.menu.menuItemPrice;        
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }

  

  addToCart(menuItem) {
    if(this.authService.checkedInState.value == false){
      this.openToast();
    }else{
      this.cartService.addMenuItem(menuItem);
      this.animateCSS('animate_tada');      
    }
    
  }

  goToRestaurantList(){
    this.nav.navigateRoot('restaurant-list')
  }

  openToast(){    
    let snackBarRef = this.toast.open('Please check in to start your order','Check In',{duration:5000});
    snackBarRef.afterDismissed()
      .subscribe(() => {
        this.nav.navigateRoot('qr-scanner');
      })
  }

  async openCart() {

    if(this.authService.checkedInState.value == false){
      this.openToast();
    }else{
      if (this.cartItemCount.value === 0){
        let alert = await this.alertCtrl.create({
          header: 'Cart Empty!',
          message: 'There are no items in you cart',
          buttons: ['OK']
        });
        alert.present().then(() => {
          this.modalCtrl.dismiss();
        });
      }
      else{
        this.animateCSS('animate_bounceOutLeft', true);
   
        let modal = await this.modalCtrl.create({
          component: CartModalPage,
          cssClass: 'cart-modal'
        });
        modal.onWillDismiss().then(() => {
          this.fab.nativeElement.classList.remove('animated', 'animate_bounceOutLeft')
          this.animateCSS('animate_bounceInLeft');
        });
        
        modal.present();
      }
    }   
  }
 
  animateCSS(animationName, keepAnimated = false) {
    const node = this.fab.nativeElement;
    node.classList.add(`animate_animated`, animationName)
    
    //https://github.com/daneden/animate.css
    function handleAnimationEnd() {
      if (!keepAnimated) {
        node.classList.remove('animate_animated', animationName);
      }
      node.removeEventListener('animationend', handleAnimationEnd)
    }
    node.addEventListener('animationend', handleAnimationEnd)
  }

  logout(){
    this.authService.logout()
  }

}
