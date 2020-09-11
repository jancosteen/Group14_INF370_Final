import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router'; 

import {WrittenOffStock} from 'src/app/_interfaces/Product/writtenoffstock/writtenoffstock.model';

 
@Component({
  selector: 'app-writtenoffstock-delete',
  templateUrl: './writtenoffstock-delete.component.html',
  styleUrls: ['./writtenoffstock-delete.component.css']
})
export class WrittenoffstockDeleteComponent implements OnInit {
  public errorMessage: string = '';
  public writtenoffstock: WrittenOffStock;

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void { 
    this.getWrittenOffStockId();
  }

  private getWrittenOffStockId = () => {
    let WrittenOfStockId: string = this.activeRoute.snapshot.params['id'];
      
    let WrittenOfStockIdByIdUrl: string = 'api/writtenoffstock/'+WrittenOfStockId;
   
    this.repository.getData(WrittenOfStockIdByIdUrl)
      .subscribe(res => {
        this.writtenoffstock = res as WrittenOffStock;
 

      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }

  public deleteWrittenOffStock = () => {
    const deleteUrl: string = 'api/writtenoffstock/' + this.writtenoffstock.WrittenOfStockId ;

    this.repository.delete(deleteUrl)
      .subscribe(res => {
 
        $('#successModal').modal();
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }

  public redirectTowrittenoffstockList(){
    this.router.navigate(['/writtenoffstock/list']); 
  }

}
