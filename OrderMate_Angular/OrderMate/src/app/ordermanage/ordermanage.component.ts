import { Order } from './../_interfaces/Order/Order/order.model';
import { OrderStatus } from './../_interfaces/Order/OrderStatus/orderstatus.model';
import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { ErrorHandlerService } from '../shared/services/error-handler.service';
import { RepositoryService } from '../shared/services/repository.service';
import { Router } from '@angular/router'; 
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { datepicker } from 'jquery';
import { ConvertActionBindingResult } from '@angular/compiler/src/compiler_util/expression_converter';

@Component({
  selector: 'app-ordermanage',
  templateUrl: './ordermanage.component.html',
  styleUrls: ['./ordermanage.component.css']
})
export class OrdermanageComponent implements OnInit {
  orders: Order[];
  orderStatuses: OrderStatus[];
  ordersFromServer:Order[];

  selectedOrderStatus: Order;


  constructor(private repository :  RepositoryService, private errorHandler: ErrorHandlerService, 
    private router: Router) { }

    ngOnInit(): void {

      let apiAddress: string = "api/order";
      this.repository.getData(apiAddress)
        .subscribe(res => {
          this.ordersFromServer = res as Order[];
          console.log('from serve', this.ordersFromServer)
          //iterate through the list, for each statusId find match in status list and retrive status name
          this.orders =[];
          this.ordersFromServer.forEach(order=>{
            //formet date here
            //call method and pass reservation here
            let apiAddress: string = "api/orderstatus";
        this.repository.getData(apiAddress)
        .subscribe(res => {
          this.orderStatuses = res as OrderStatus[];
          this.orderStatuses.forEach(status=>{
            if(order.orderId == status.orderId){
              //match found              
              order.orderStatus = status.orderStatus;
              this.orders.push(order);
              console.log('reservations',this.orders)
            }
          })
        });
  
            
          })
    
        });
     
    }

}
