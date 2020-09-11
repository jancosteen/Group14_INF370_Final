import { Order } from './../../../_interfaces/Order/Order/order.model';
import { OrderStatus } from './../../../_interfaces/Order/OrderStatus/orderstatus.model';
import { Special } from 'src/app/_interfaces/Order/Special/special.model';
import { MenuItem } from './../../../_interfaces/menumange/MenuItem/menuitem.model';
import { Component, OnInit, Inject } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { OrderLine} from '../../../_interfaces/Order/Orderline/orderline.model'
import { subscribeOn } from 'rxjs/operators';



export interface DialogData {
  status: OrderStatus[];
}

@Component({
  selector: 'app-orderline-details',
  templateUrl: './orderline-details.component.html',
  styleUrls: ['./orderline-details.component.css']
})


export class OrderlineDetailsComponent implements OnInit {
  public orderLine: OrderLine;
  public errorMessage: string = ''; 
  status:string;
  menuItems: MenuItem[];
  orderlineitems: MenuItem[];
  specials: Special[];
  orderlinespecials: Special[];
  orderStatuses: OrderStatus[];
  orderlineidfromurl :string = this.activeRoute.snapshot.params['id'];
  statusList : OrderStatus[];
  selectedStatus: OrderStatus;
  order: Order;
  constructor(private repository: RepositoryService, private router: Router,  
    private activeRoute: ActivatedRoute, 
    private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getMenuItems();
    this.getDetails();
    this.getStatus();
    this.geStatusList();
  }

  geStatusList(){
    let apiUrl: string = 'api/orderstatus';
 
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.statusList = res as OrderStatus[];
      console.log('statuslist', this.statusList)
    }) 

  }

  saveStatusUpdate(){
    
    
    let IdUrl: string = 'api/order/'+ this.orderLine.orderIdFk;
    this.repository.getData(IdUrl)
      .subscribe(res => {
        this.order = res as Order;
        console.log('order',this.order)
        this.order.orderStatus1 = this.selectedStatus.orderStatusId
        let apiUrl = 'api/order/' + this.orderlineidfromurl;
        this.repository.update(apiUrl, this.order)
          .subscribe(res => {
            $('#successModal').modal();
          },
          (error => {
            this.errorHandler.handleError(error); 
            this.errorMessage = this.errorHandler.errorMessage;
          })
       )
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
      
  }


  getDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    
    let apiUrl: string = 'api/orderline/'+id;
 
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.orderLine = res as OrderLine;
      
      this.orderlinespecials = [];
    let apiAddress: string = "api/special";
        this.repository.getData(apiAddress)
        .subscribe(res => {
          this.specials = res as Special[];
          this.specials.forEach(special =>{
            if(special.specialId == this.orderLine.specialIdFk ){
              this.orderlinespecials.push(special)
            }
          })
        });
    
    },
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }
  orderlines : OrderLine;
  orderId : number;
  statusName: string = '';
  getStatus(){
    let id: string = this.activeRoute.snapshot.params['id'];
    console.log('id',id)
    let apiUrl: string = 'api/orderline/' + id;
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.orderlines = res as OrderLine;
      console.log('orderlines', this.orderlines);
      this.orderId = this.orderlines.orderIdFk;
      console.log('orderid', this.orderId)
        let statusAddress: string ="api/orderstatus";
        this.repository.getData(statusAddress)
          .subscribe(res => {
            this.orderStatuses = res as OrderStatus[];
            console.log('statuslist',this.orderStatuses)
            this.orderStatuses.forEach(status =>{
            if(status.orderIdFk == this.orderId){
              console.log('status', status.orderStatus1)
              this.statusName = status.orderStatus1
            
            }      
          })
        })
    
      
    })          
  }


  

  getMenuItems(){
    let menuItemAddress: string = "api/menuitem";
    this.orderlineitems = []
        this.repository.getData(menuItemAddress)
        .subscribe(res => {
          this.menuItems = res as MenuItem[];
          this.menuItems.forEach(item =>{
            if(item.menuItemId == this.orderlineidfromurl){
              this.orderlineitems.push(item)
            }
          })
        })
  }

  public returnToOrderList = () => { 
    const updateUrl: string = '/ordermanage'; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToUpdate = (orderId) => { 
    const deleteUrl: string = '/order/update/' + orderId; 
    this.router.navigate([deleteUrl]); 
  }
}


