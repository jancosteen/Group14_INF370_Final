import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';

import { SupplierOrder } from 'src/app/_interfaces/Supplier/SupplierOrder/supplierorder.model';

@Component({
  selector: 'app-supplierorder-delete',
  templateUrl: './supplierorder-delete.component.html',
  styleUrls: ['./supplierorder-delete.component.css']
})
export class SupplierorderDeleteComponent implements OnInit {
  public supplierorder: SupplierOrder;
  public errorMessage: string = '';

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

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

  public deleteSupplierOrder = () => {
    const deleteUrl: string = 'api/supplierOrder/' + this.supplierorder.SupplierOrderId ;

    this.repository.delete(deleteUrl)
      .subscribe(res => {
      
        $('#successModal').modal();
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }

  public redirectToSupplierOrderList = () => {
    this.router.navigate(['/supplierOrder/list']);
  }

}
