import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../shared/services/repository.service';
import { ErrorHandlerService } from './../../shared/services/error-handler.service';


import { Supplier } from './../../_interfaces/supplier/supplier.model';
 


@Component({ 
  selector: 'app-supplier-details',
  templateUrl: './supplier-details.component.html',
  styleUrls: ['./supplier-details.component.css']
})
export class SupplierDetailsComponent implements OnInit {
  public supplier: Supplier;
  public errorMessage: string = '';

  constructor(private repository: RepositoryService, private router: Router, 
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    
    this.getSupplierDetails();
   
  }

  getSupplierDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    console.log('id',id);
    let apiUrl: string = 'api/supplier/'+id+'/supplierOrder';
 
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.supplier = res as Supplier;
    },
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }


  public redirectToUpdatePage = (supplierId) => { 
    const updateUrl: string = '/supplier/update/' + supplierId; 
    console.log('thiseee',updateUrl);
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (supplierId) => { 
    const deleteUrl: string = '/supplier/delete/' + supplierId; 
    console.log('thiseee',deleteUrl);
    this.router.navigate([deleteUrl]); 
  }

}
