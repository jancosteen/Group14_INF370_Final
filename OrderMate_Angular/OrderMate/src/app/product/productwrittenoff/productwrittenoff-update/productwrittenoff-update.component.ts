import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';

import { ProductWrittenOff } from '../../../_interfaces/Product/ProductWrittenOff/productwrittenoff.model';

@Component({
  selector: 'app-productwrittenoff-update',
  templateUrl: './productwrittenoff-update.component.html',
  styleUrls: ['./productwrittenoff-update.component.css']
})
export class ProductwrittenoffUpdateComponent implements OnInit {
  public errorMessage: string = '';
 
  public productwrittenoffForm: FormGroup;

  public productwrittenoff: ProductWrittenOff;

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.productwrittenoffForm = new FormGroup({
      ProductWrittenOffId: new FormControl(''),
      WrittenOffQty: new FormControl('',[Validators.required, Validators.maxLength(100)]),
      WrittenOffStockIdFk: new FormControl('',[Validators.required, Validators.maxLength(100)]),
      ProductIdFk: new FormControl('',[Validators.required, Validators.maxLength(100)]),
      Employee: new FormControl('',[Validators.required, Validators.maxLength(100)]),
    });

    this.getProductWrittenOffById();
  } 

  private getProductWrittenOffById = () => {
    let ProductWrittenOffId: string = this.activeRoute.snapshot.params['id'];
      
    let productWrittenOffIdByIdUrl: string = 'api/prodWrittenOff/'+ProductWrittenOffId;
   
    this.repository.getData(productWrittenOffIdByIdUrl)
      .subscribe(res => {
        this.productwrittenoff = res as ProductWrittenOff;
     
        this.productwrittenoffForm.patchValue(this.productwrittenoff);

      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
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

  public redirectToProductWrittenOffList(){
    this.router.navigate(['/prodWrittenOff/list']);
  }

  public updateProductWrittenOff = (productwrittenoffFormValue) => {
    if (this.productwrittenoffForm.valid) {
      this.executeProductWrittenOffUpdate(productwrittenoffFormValue);
    }
  }

  private executeProductWrittenOffUpdate = (productwrittenoffValue) => {
  

    this.productwrittenoff.ProductWrittenOffId =  productwrittenoffValue.ProductWrittenOffId,
    this.productwrittenoff.WrittenOffQty = productwrittenoffValue.WrittenOffQty,
    this.productwrittenoff.WrittenOffStockIdFk = productwrittenoffValue.WrittenOffStockIdFk,
    this.productwrittenoff.ProductIdFk = productwrittenoffValue.ProductIdFk,
    this.productwrittenoff.Employee = productwrittenoffValue.Employee
    
   
    let apiUrl = 'api/prodWrittenOff/' + this.productwrittenoff.ProductWrittenOffId;
    this.repository.update(apiUrl, this.productwrittenoff)
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
