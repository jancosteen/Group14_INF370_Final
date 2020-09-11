import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router'; 

import { StockTake} from 'src/app/_interfaces/Product/StockTake/stocktake.model';

@Component({
  selector: 'app-stocktake-update',
  templateUrl: './stocktake-update.component.html',
  styleUrls: ['./stocktake-update.component.css']
})
export class StocktakeUpdateComponent implements OnInit {

  public errorMessage: string = '';
 
  public Stocktake: StockTake;
  public StockTakeForm: FormGroup;

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.StockTakeForm = new FormGroup({
      stocktakeId: new FormControl(''),
      stocktakeDate: new FormControl('',[Validators.required]),
    });

    this.getStockTakeById();
  }


  private getStockTakeById = () => {
    let stocktakeId: string = this.activeRoute.snapshot.params['id'];
      
    let stocktakeIdByIdUrl: string = 'api/stocktake/'+stocktakeId;
   
    this.repository.getData(stocktakeIdByIdUrl)
      .subscribe(res => {
        this.Stocktake = res as StockTake;
     
        this.StockTakeForm.patchValue(this.Stocktake);

      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
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

  public redirectToStockTakeList(){
    this.router.navigate(['/stocktake/list']);
  }


  public updateStockTake = (StockTakeFormValue) => {
    if (this.StockTakeForm.valid) {
      this.executeStockTakeUpdate(StockTakeFormValue);
    }
  }

  private executeStockTakeUpdate = (StockTakeFormValue) => {
  
    this.Stocktake.stocktakeId =  StockTakeFormValue.stocktakeId,
    this.Stocktake.stocktakeDate = StockTakeFormValue.stocktakeDate
    
   
    let apiUrl = 'api/stocktake/' + this.Stocktake.stocktakeId;
    this.repository.update(apiUrl, this.Stocktake)
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
