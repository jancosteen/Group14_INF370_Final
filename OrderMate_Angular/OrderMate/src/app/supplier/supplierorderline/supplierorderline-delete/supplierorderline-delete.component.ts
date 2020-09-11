import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';

import {SupplierOrderLine} from '../../../_interfaces/Supplier/SupplierOrderLine/supplierorderline.model'


@Component({
  selector: 'app-supplierorderline-delete',
  templateUrl: './supplierorderline-delete.component.html',
  styleUrls: ['./supplierorderline-delete.component.css']
})
export class SupplierorderlineDeleteComponent implements OnInit {

  public errorMessage: string = '';
  public supplierOrderLine: SupplierOrderLine;
  

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

    ngOnInit(): void{
      this.getById();
    }
     
    private getById = () => {
      let supplierorderlineId: string = this.activeRoute.snapshot.params['id'];
        
      let ByIdUrl: string = 'api/supplierorderline/'+supplierorderlineId;
     
      this.repository.getData(ByIdUrl)
        .subscribe(res => {
          this.supplierOrderLine = res as SupplierOrderLine;
        },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        })
    }
     
    public redirectToList = () => {
      this.router.navigate(['/supplierorderline/list']);
    }

    public delete = () => {
      const deleteUrl: string = 'api/supplierorderline/' + this.supplierOrderLine.supplierOrderLineId ;
     
      this.repository.delete(deleteUrl)
        .subscribe(res => {
     
          $('#successModal').modal();
        },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        })
    }

}
