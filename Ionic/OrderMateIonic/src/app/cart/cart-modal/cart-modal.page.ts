import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/shared/services/cart.service';
import { ModalController, AlertController, NavController } from '@ionic/angular';
import { MenuItem } from 'src/app/_interfaces/menuItem.model';
import { OrderForCreation } from 'src/app/_interfaces/ForCreation/orderForCreation.model';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import {formatDate} from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { OrderLineForCreation } from 'src/app/_interfaces/ForCreation/orderLineForCreation.model';
//import { runInThisContext } from 'vm';
import { Order } from 'src/app/_interfaces/order.model';
import { Observable } from 'rxjs';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { qrCodeSeating } from 'src/app/_interfaces/ForCreation/qrCodeSeatingForCreation.model';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';


@Component({
  selector: 'app-cart-modal',
  templateUrl: './cart-modal.page.html',
  styleUrls: ['./cart-modal.page.scss'],
})
export class CartModalPage implements OnInit {
  
  cart: MenuItem[] = [];
  order: OrderForCreation;
  orderLine: OrderLineForCreation;
  currentDate: string;
  public createdOrderId: number;
  orderIdCreated;
  createdOrderLineId;
  createdOrder: Order;
  orderIdString:string;
  qrCodeId:string;
  seatingId:string;
  itmComment;

  cartForm: FormGroup;
 
  constructor(private http: HttpClient,private repository: RepositoryService,
     private cartService: CartService, private modalCtrl: ModalController,
      private alertCtrl: AlertController,
      private auth: AuthenticationService,
      private toast: MatSnackBar,
      private nav: NavController,
      private fb: FormBuilder,) { }
 
  ngOnInit() {
    this.cart = this.cartService.getCart();
    this.currentDate = formatDate(new Date(), 'yyyy-MM-dd', 'en');
    this.createOrder();
    this.cartForm = this.fb.group({
      itemComment: new FormControl('')
    })
  }
 
  decreaseCartItem(product) {
    this.cartService.decreaseMenuItem(product);
  }
 
  increaseCartItem(product) {
    this.cartService.addMenuItem(product);
  }
 
  removeCartItem(product) {
    this.cartService.removeMenuItem(product);
  }
 
  getTotal() {
    return this.cart.reduce((i, j) => i + j.menuItemAmount * j.menuItemPrice[0].menuItemPrice1, 0);
  }
  openToast(){    
    let snackBarRef = this.toast.open('Please check in to start your order','Ok',{duration:3000});
    snackBarRef.afterDismissed()
      .subscribe(() => {
        this.nav.navigateRoot('qr-scanner');
      })
  }
 
  close() {
    this.modalCtrl.dismiss();
  }
 
  async checkout(cartFormValue) {
    // Perfom PayPal or Stripe checkout process
    this.itmComment = cartFormValue.itemComment;
    this.createOrderLine(this.createdOrder.orderId,this.itmComment);
    this.updateQrCodeSeating();

    let alert = await this.alertCtrl.create({
      header: 'Thanks for your Order!',
      message: 'We will deliver your food as soon as possible',
      buttons: ['OK']
    });
    alert.present().then(() => {
      this.modalCtrl.dismiss();
    });   

    this.cart = []; 
     
    this.cartService.removeCartItemCount(); 
  }

  createOrder(){

    if (!this.auth.checkedInState){
      this.openToast();
    }else{
      
      const orderForCreation: OrderForCreation = {
        orderDateCreated: this.currentDate,
        orderDateCompleted: this.currentDate,
        qrCodeSeatingIdFk: +localStorage.getItem('qrCodeId'),
        //orderStatus: 1
      };    
  
      const apiUrlOrder = 'api/order';
      
      this.repository.create(apiUrlOrder,orderForCreation)
        .subscribe( res =>{
          this.createdOrderId = res.orderId; 
          this.repository.getData(apiUrlOrder+`/${this.createdOrderId}`)
            .subscribe(res2 => {
              this.createdOrder = res as Order
              this.createdOrderId = this.createdOrder.orderId;
            }) ;    
      });
    }     
  } 

  updateQrCodeSeating(){
    this.qrCodeId = localStorage.getItem('qrCodeId');
    this.seatingId = localStorage.getItem('seatingId');
    this.orderIdString = localStorage.getItem('orderId')
    const apiUrl = `api/qrCodeSeating/${this.qrCodeId}/${this.seatingId}`;

    const qrCodeSeatingForUpdate: qrCodeSeating = {
      qrCodeIdFk : +this.qrCodeId,
      seatingIdFk: +this.seatingId,
      nrOfPeople: 1,
      orderIdFk: +this.orderIdString,
    }

    this.repository.update(apiUrl, qrCodeSeatingForUpdate)
      .subscribe(res => {
        console.log(res);
      })
  }
  
  

  createOrderLine(id,comment){
    const apiUrlOLine = 'api/orderLine';
    for (let i = 0; i< this.cart.length; i++){
      const orderLineForCreation: OrderLineForCreation = {
        orderIdFk : id,
      itemQty : this.cart[i].menuItemAmount,
      itemComments : comment,
      menuItemIdFk : this.cart[i].menuItemId,
      specialIdFk : 1,
      employeeIdFk : 1,
      }

      this.orderIdString = id;
      localStorage.setItem('orderId',this.orderIdString);

      
      this.repository.create(apiUrlOLine, orderLineForCreation)
        .subscribe(res => {
          this.createdOrderLineId = res.orderLineId;
          console.log(this.createdOrderLineId);
        });      
    }
  }
}

