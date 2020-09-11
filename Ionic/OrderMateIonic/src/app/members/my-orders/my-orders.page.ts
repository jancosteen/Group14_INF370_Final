import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/_interfaces/order.model';
import { OrderLine } from 'src/app/_interfaces/orderLine.model';
import { MenuItem } from 'src/app/_interfaces/menuItem.model';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { MenuItemPrice } from 'src/app/_interfaces/menuItemPrice.model';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-my-orders',
  templateUrl: './my-orders.page.html',
  styleUrls: ['./my-orders.page.scss'],
})
export class MyOrdersPage implements OnInit {

  qrCodeId;
  orderIdInt:number;
  orderIdString1:string;
  orderIdString2:string;
  order:Order;
  orderLine:OrderLine[];
  orderLineId:number;
  orderLineIdString:string;
  menuItems:MenuItem[];
  menuItemPrice:MenuItemPrice;
  public errorMessage: string = '';

  constructor(private repository: RepositoryService
    ,private errorHandler: ErrorHandlerService
    ,private authService: AuthenticationService) { }

  ngOnInit() {
    this.getOrder();
    this.orderIdString2 = localStorage.getItem('orderId');
    this.getOrderLine(this.orderIdString2);
  }

  getOrder(){
    this.qrCodeId = localStorage.getItem('qrCodeId');

    const apiUrl = `api/order/${this.qrCodeId}/qrCode`;
    this.repository.getData(apiUrl)
      .subscribe(res => {
        this.order = res as Order;
        this.orderIdInt = this.order.orderId;
        this.orderIdString1 = this.orderIdInt.toString();
        localStorage.setItem('orderId',this.orderIdString1);
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      });
  }

  getOrderLine(id){
    

    const apiUrl1 = `api/orderLine/${id}/orderId`;
    this.repository.getData(apiUrl1)
      .subscribe(res =>{
        this.orderLine = res as OrderLine[];
        console.log(this.orderLine);           
        
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      });
  }
  logout(){
    this.authService.logout()
  }


}
