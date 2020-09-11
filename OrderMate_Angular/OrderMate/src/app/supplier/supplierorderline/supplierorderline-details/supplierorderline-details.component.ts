import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';

import {SupplierOrderLine} from '../../../_interfaces/Supplier/SupplierOrderLine/supplierorderline.model'

@Component({
  selector: 'app-supplierorderline-details',
  templateUrl: './supplierorderline-details.component.html',
  styleUrls: ['./supplierorderline-details.component.css']
})
export class SupplierorderlineDetailsComponent implements OnInit {
  public supplierOrderLine: SupplierOrderLine;
  public errorMessage: string = '';

  constructor(private repository: RepositoryService, private router: Router, 
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    
    this.getDetails();
   
  }

  getDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    console.log('id',id);
    let apiUrl: string = 'api/supplierorderline/'+id+'/supplierOrder';
 
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.supplierOrderLine = res as SupplierOrderLine;
    },
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }

  
  public redirectToUpdatePage = (supplierOrderLineId) => { 
    const updateUrl: string = '/supplierorderline/update/' + supplierOrderLineId; 
    console.log('thiseee',updateUrl);
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (supplierOrderLineId) => { 
    const deleteUrl: string = '/supplierorderline/delete/' + supplierOrderLineId; 
    console.log('thiseee',deleteUrl);
    this.router.navigate([deleteUrl]); 
  }

}
