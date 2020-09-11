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
import { OrderLine } from '../_interfaces/Order/Orderline/orderline.model';

@Component({
  selector: 'app-ordermanage',
  templateUrl: './ordermanage.component.html',
  styleUrls: ['./ordermanage.component.css']
})
export class OrdermanageComponent implements OnInit {
  orders: Order[];
  orderStatuses: OrderStatus[];
  ordersFromServer:Order[];
  orderlines: OrderLine[]

  selectedOrderStatus: Order;


  constructor(private repository :  RepositoryService, private errorHandler: ErrorHandlerService, 
    private router: Router) { }

    ngOnInit(): void {

      let apiAddress: string = "api/order";
      this.repository.getData(apiAddress)
        .subscribe(res => {
          this.ordersFromServer = res as Order[];
     
          //iterate through the list, for each statusId find match in status list and retrive status name
          this.orders =[];
          this.ordersFromServer.forEach(order=>{
            let statusAddress: string ="api/orderstatus";
            this.repository.getData(statusAddress)
            .subscribe(res => {
              this.orderStatuses = res as OrderStatus[];
              this.orderStatuses.forEach(status =>{
                console.log(order.orderStatus1)
                if(order.orderStatus1 == status.orderStatusId){
                
                  order.orderStatusName = status.orderStatus1
                  this.orders.push(order)
                  console.log('orders',this.orders)
               
                }
              })
            })
            
          })
    
        });
      
    }


    public goToOrder(value){
   
      let orderlineId
      //get all orderlines
      let apiAddress: string = "api/orderline";
        this.repository.getData(apiAddress)
        .subscribe(res => {
          this.orderlines = res as OrderLine[];

          this.orderlines.forEach(orderline=>{
         
            if(orderline.orderIdFk == value){
        
              orderlineId = orderline.orderLineId
         
              const OrderLineUrl: string = '/orderline/details/' + orderlineId; 
  
              this.router.navigate([OrderLineUrl]); 
            }
          
          })
        });
        
        
      
    }

}
