import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';

import { SupplierOrder } from 'src/app/_interfaces/Supplier/SupplierOrder/supplierorder.model';

@Component({
  selector: 'app-supplierorder-details',
  templateUrl: './supplierorder-details.component.html',
  styleUrls: ['./supplierorder-details.component.css']
})
export class SupplierorderDetailsComponent implements OnInit {
  public supplierorder: SupplierOrder;
  public errorMessage: string = '';

  constructor(private repository: RepositoryService, private router: Router, 
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getSupplierOrderDetails();
  } 

  getSupplierOrderDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];

    let apiUrl: string = 'api/supplierOrder/'+id;
 
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.supplierorder = res as SupplierOrder;
    },
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }

  public redirectToUpdatePage = (supplierorderId) => { 
    const updateUrl: string = '/supplierOrder/update/' + supplierorderId; 

    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (supplierorderId) => { 
    const deleteUrl: string = '/supplierOrder/delete/' + supplierorderId; 
   
    this.router.navigate([deleteUrl]); 
  }

}
