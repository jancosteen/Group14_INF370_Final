import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router } from '@angular/router';

import { CreateStockTake} from 'src/app/_interfaces/Product/StockTake/stocktakecreate.model';


@Component({
  selector: 'app-stocktake-create',
  templateUrl: './stocktake-create.component.html',
  styleUrls: ['./stocktake-create.component.css']
})
export class StocktakeCreateComponent implements OnInit {
  public errorMessage: string = '';
 
  public Stocktake: CreateStockTake;
  public StockTakeForm: FormGroup;

  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
    private router: Router ) { }

 ngOnInit(): void {

   this.StockTakeForm = new FormGroup({
    stocktakeDate: new FormControl('',[Validators.required, Validators.maxLength(100)])
   });

 }

 public validateControl = (controlName: string) => {
  if (this.StockTakeForm.controls[controlName].invalid && this.StockTakeForm.controls[controlName].touched)
    return true;

  return false;
}

public hasError = (controlName: string, errorName: string) => {
  if (this.StockTakeForm.controls[controlName].hasError(errorName))
    return true;

  return false;
}


 public createStockTake = (StockTakeFormValue) => {
  if (this.StockTakeForm.valid) {
    this.executeStockTakeCreate(StockTakeFormValue);
  }
}

private executeStockTakeCreate = (StockTakeFormValue) => {
  const StockTake : CreateStockTake ={
    
  stocktakeDate : StockTakeFormValue.stocktakeDate
  }
  
  
 
  let apiUrl = 'api/stocktake/' + StockTake;
  this.repository.update(apiUrl, StockTake)
    .subscribe(res => {
      $('#successModal').modal();
    },
    (error => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  )
}


 public redirectToStockTakeList(){
  this.router.navigate(['/stocktake/list']); 
}

}
