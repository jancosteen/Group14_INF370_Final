import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../shared/services/error-handler.service';
import { RepositoryService } from './../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';

import { Supplier } from './../../_interfaces/supplier/supplier.model'; 

 
@Component({
  selector: 'app-supplier-delete',
  templateUrl: './supplier-delete.component.html',
  styleUrls: ['./supplier-delete.component.css']
})
export class SupplierDeleteComponent implements OnInit {

  public errorMessage: string = '';
  public supplier: Supplier;
  

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

    ngOnInit(): void{
      this.getSupplierById();
    }
     
    private getSupplierById = () => {
      let supplierId: string = this.activeRoute.snapshot.params['id'];
        
      let supplierByIdUrl: string = 'api/supplier/'+supplierId;
     
      this.repository.getData(supplierByIdUrl)
        .subscribe(res => {
          this.supplier = res as Supplier;
        },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        })
    }
     
    public redirectToSupplierList = () => {
      this.router.navigate(['/supplier/list']);
    }

    public deleteSupplier = () => {
      const deleteUrl: string = 'api/supplier/' + this.supplier.supplierId ;
     // console.log('supp',this.supplier);
     // console.log('supp',this.supplier.supplierId);
      this.repository.delete(deleteUrl)
        .subscribe(res => {
          console.log('do i go in here???');
          $('#successModal').modal();
        },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        })
    }

}
