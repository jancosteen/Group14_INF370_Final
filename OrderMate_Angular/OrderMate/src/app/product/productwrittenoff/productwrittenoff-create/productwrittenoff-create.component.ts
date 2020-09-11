import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router } from '@angular/router';

import { CreateProductWrittenOff } from '../../../_interfaces/Product/ProductWrittenOff/productwrittenoffcreate.model';

@Component({
  selector: 'app-productwrittenoff-create',
  templateUrl: './productwrittenoff-create.component.html',
  styleUrls: ['./productwrittenoff-create.component.css']
})
export class ProductwrittenoffCreateComponent implements OnInit {
  public errorMessage: string = '';
 
  public productwrittenoffForm: FormGroup;

  public productwrittenoff: CreateProductWrittenOff;

  constructor(private errorHandler: ErrorHandlerService, private repository: RepositoryService,
    private router: Router) { }

  ngOnInit(): void { 
    this.productwrittenoffForm = new FormGroup({
      ProductWrittenOffId: new FormControl('',[Validators.required, Validators.maxLength(100)]),
      WrittenOffQty: new FormControl('',[Validators.required, Validators.maxLength(100)]),
      WrittenOffStockIdFk: new FormControl('',[Validators.required, Validators.maxLength(100)]),
      ProductIdFk: new FormControl('',[Validators.required, Validators.maxLength(100)]),
      Employee: new FormControl('',[Validators.required, Validators.maxLength(100)]),
    });
  }

  public validateControl = (controlName: string) => {
    if (this.productwrittenoffForm.controls[controlName].invalid && this.productwrittenoffForm.controls[controlName].touched)
      return true;
 
    return false;
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.productwrittenoffForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

  public createProductWrittenOff = (productwrittenoffValue) => {
    if (this.productwrittenoffForm.valid) {
      this.executeProductWrittenCreation(productwrittenoffValue);
    }
  }
  private executeProductWrittenCreation = (productwrittenoffValue) => {

    const productwrittenoff: CreateProductWrittenOff = {
    WrittenOffQty : productwrittenoffValue.WrittenOffQty,
    WrittenOffStockIdFk : productwrittenoffValue.WrittenOffStockIdFk,
    ProductIdFk : productwrittenoffValue.ProductIdFk,
    Employee : productwrittenoffValue.Employee
   
    }
 
    const apiUrl = 'api/prodWrittenOff';
    this.repository.create(apiUrl, productwrittenoff)
      .subscribe(res => {
        $('#successModal').modal();
      },
      (error => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    )
  }

  public redirectToProductWrittenOffList(){
    this.router.navigate(['/prodWrittenOff/list']);
  }


}
