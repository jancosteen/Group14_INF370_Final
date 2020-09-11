import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router'; 
 

import {WrittenOffStock} from 'src/app/_interfaces/Product/writtenoffstock/writtenoffstock.model';

@Component({
  selector: 'app-writtenoffstock-update',
  templateUrl: './writtenoffstock-update.component.html',
  styleUrls: ['./writtenoffstock-update.component.css']
})
export class WrittenoffstockUpdateComponent implements OnInit {

  public errorMessage: string = '';
 
  public writtenoffstockForm: FormGroup;

  public writtenoffstock: WrittenOffStock;

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { } 

    ngOnInit(): void {
      this.writtenoffstockForm = new FormGroup({
        WrittenOfStockId: new FormControl(''),
        WrittenOfStockDate: new FormControl('',[Validators.required])
      });
  
      this.getWrittenOffStockId();
    }

    private getWrittenOffStockId = () => {
      let WrittenOfStockId: string = this.activeRoute.snapshot.params['id'];
        
      let WrittenOfStockIdByIdUrl: string = 'api/writtenoffstock/'+WrittenOfStockId;
     
      this.repository.getData(WrittenOfStockIdByIdUrl)
        .subscribe(res => {
          this.writtenoffstock = res as WrittenOffStock;
       
          this.writtenoffstockForm.patchValue(this.writtenoffstock);
  
        },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        })
    }

    public validateControl = (controlName: string) => {
      if (this.writtenoffstockForm.controls[controlName].invalid && this.writtenoffstockForm.controls[controlName].touched)
        return true;
   
      return false;
    }
   
    public hasError = (controlName: string, errorName: string) => {
      if (this.writtenoffstockForm.controls[controlName].hasError(errorName))
        return true;
   
      return false;
    }
  
    public redirectTowrittenoffstockList(){
      this.router.navigate(['/writtenoffstock/list']); 
    }

    public updateWrittenOffStock = (WrittenOffStockFormValue) => {
      if (this.writtenoffstockForm.valid) {
        this.executeWrittenOffStockUpdate(WrittenOffStockFormValue);
      }
    } 
  
    private executeWrittenOffStockUpdate = (WrittenOffStockFormValue) => {
    
      this.writtenoffstock.WrittenOfStockId =  WrittenOffStockFormValue.WrittenOfStockId,
      this.writtenoffstock.WrittenOfStockDate = WrittenOffStockFormValue.WrittenOfStockDate
      
     
      let apiUrl = 'api/writtenoffstock/' + this.writtenoffstock.WrittenOfStockId;
      this.repository.update(apiUrl, this.writtenoffstock)
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
