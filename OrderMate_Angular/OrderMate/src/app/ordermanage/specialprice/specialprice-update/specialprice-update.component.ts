import { Component, OnInit } from '@angular/core'; 
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';  

import {SpecialPrice} from '../../../../app/_interfaces/Order/SpecialPrice/specialprice.model';

@Component({
  selector: 'app-specialprice-update',
  templateUrl: './specialprice-update.component.html',
  styleUrls: ['./specialprice-update.component.css']
})
export class SpecialpriceUpdateComponent implements OnInit {

  public errorMessage: string = '';
 
  public specialPriceForm: FormGroup;

  public specialPrice: SpecialPrice; 

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.specialPriceForm = new FormGroup({
      specialPriceId: new FormControl(''),
      specialPrice: new FormControl('',[Validators.required, Validators.maxLength(100)]),
      specialPriceDateUpdate: new FormControl('',[Validators.required, Validators.maxLength(100)]),
      special: new FormControl('',[Validators.required, Validators.maxLength(100)]),

    });

    this.getSpecialPriceById();
  }

  private getSpecialPriceById = () => {
    let specialPriceId: string = this.activeRoute.snapshot.params['id'];
      
    let IdUrl: string = 'api/specialprice/'+specialPriceId;
   
    this.repository.getData(IdUrl)
      .subscribe(res => {
        this.specialPrice = res as SpecialPrice;
     
        this.specialPriceForm.patchValue(this.specialPrice);

      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }
  public validateControl = (controlName: string) => {
    if (this.specialPriceForm.controls[controlName].invalid && this.specialPriceForm.controls[controlName].touched)
      return true;
 
    return false;
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.specialPriceForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

  public redirectTospecialPriceList(){
    this.router.navigate(['/specialPrice/list']);
  }


  public update = (specialPriceFormFormValue) => {
    if (this.specialPriceForm.valid) {
      this.executeUpdate(specialPriceFormFormValue);
    }
  }

  private executeUpdate = (specialPriceFormFormValue) => {
  
    this.specialPrice.specialPriceId =  specialPriceFormFormValue.specialPriceId,
    this.specialPrice.specialPrice = specialPriceFormFormValue.specialPrice,
    this.specialPrice.specialPriceDateUpdate = specialPriceFormFormValue.specialPriceDateUpdate,
    this.specialPrice.special = specialPriceFormFormValue.special
    
   
    let apiUrl = 'api/specialPrice/' + this.specialPrice.specialPriceId;
    this.repository.update(apiUrl, this.specialPrice)
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
 