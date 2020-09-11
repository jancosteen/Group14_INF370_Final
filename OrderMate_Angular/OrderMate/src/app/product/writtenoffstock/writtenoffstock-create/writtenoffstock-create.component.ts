import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router } from '@angular/router';

import {CreateWrittenOffStock} from 'src/app/_interfaces/Product/writtenoffstock/writtenoffstockcreate.model';

@Component({
  selector: 'app-writtenoffstock-create',
  templateUrl: './writtenoffstock-create.component.html',
  styleUrls: ['./writtenoffstock-create.component.css']
})
export class WrittenoffstockCreateComponent implements OnInit {
  public errorMessage: string = '';
 
  public writtenoffstockForm: FormGroup;

  

  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
    private router: Router ) { }

 ngOnInit(): void {

   this.writtenoffstockForm = new FormGroup({
    WrittenOfStockDate: new FormControl('',[Validators.required]),
   });

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

public create = (Value) => {
  if (this.writtenoffstockForm.valid) {
    this.executeCreation(Value);
  }
}
private executeCreation = (Value) => {

  const WrittenOfStock: CreateWrittenOffStock = {
  
    WrittenOfStockDate:Value.WrittenOfStockDate
 
  }

  const apiUrl = 'api/writtenoffstock';
  this.repository.create(apiUrl, WrittenOfStock)
    .subscribe(res => {
      $('#successModal').modal();
    },
    (error => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  )
}

public redirectTowrittenoffstockList(){
  this.router.navigate(['/writtenoffstock/list']); 
}

}
