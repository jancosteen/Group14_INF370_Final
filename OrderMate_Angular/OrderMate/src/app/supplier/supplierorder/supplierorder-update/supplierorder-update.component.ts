import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';

import { SupplierOrder } from 'src/app/_interfaces/Supplier/SupplierOrder/supplierorder.model';

@Component({
  selector: 'app-supplierorder-update',
  templateUrl: './supplierorder-update.component.html',
  styleUrls: ['./supplierorder-update.component.css']
})
export class SupplierorderUpdateComponent implements OnInit {
  public errorMessage: string = '';
 
  public supplierorderForm: FormGroup;

  public supplierorder: SupplierOrder;
  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.supplierorderForm = new FormGroup({
      SupplierOrderId: new FormControl(''),
      SupplierOrderDate: new FormControl('',[Validators.required, Validators.maxLength(20)]),
      supplierId: new FormControl(''),
      
    });

    this.getSupplierOrderById();
  }

  private getSupplierOrderById = () => {
    let SupplierOrderId: string = this.activeRoute.snapshot.params['id'];
      
    let supplierOrderByIdUrl: string = 'api/supplierorder/'+SupplierOrderId;
   
    this.repository.getData(supplierOrderByIdUrl)
      .subscribe(res => {
        this.supplierorder = res as SupplierOrder;
     
        this.supplierorderForm.patchValue(this.supplierorder);

      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }

  public validateControl = (controlName: string) => {
    if (this.supplierorderForm.controls[controlName].invalid && this.supplierorderForm.controls[controlName].touched)
      return true;
 
    return false;
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.supplierorderForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

  public redirectToSupplierOrderList(){
    this.router.navigate(['/supplierorder/list']);
  }

  public updateSupplierOrder = (supplierorderFormValue) => {
    if (this.supplierorderForm.valid) {
      //console.log('supplierFormValue', supplierorderFormValue);
      this.executeSupplierOrderUpdate(supplierorderFormValue);
    }
  }

  private executeSupplierOrderUpdate = (supplierFormValue) => {
    this.supplierorder.SupplierOrderId =supplierFormValue.SupplierOrderId,
    this.supplierorder.SupplierOrderDate =  supplierFormValue.SupplierOrderDate,
    this.supplierorder.supplierId = supplierFormValue.supplierId
    
   
    let apiUrl = 'api/supplierorder/' + this.supplierorder.SupplierOrderId;
    this.repository.update(apiUrl, this.supplierorder)
      .subscribe(res => {
        $('#successModal').modal();
      },
      (error => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    )
  }

}
