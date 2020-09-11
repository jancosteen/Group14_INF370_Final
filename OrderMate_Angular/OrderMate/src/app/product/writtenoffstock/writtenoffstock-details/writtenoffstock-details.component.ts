import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';


import {WrittenOffStock} from 'src/app/_interfaces/Product/writtenoffstock/writtenoffstock.model';

@Component({
  selector: 'app-writtenoffstock-details',
  templateUrl: './writtenoffstock-details.component.html', 
  styleUrls: ['./writtenoffstock-details.component.css']
})
export class WrittenoffstockDetailsComponent implements OnInit {

  public errorMessage: string = '';

  public writtenoffstock: WrittenOffStock;

  constructor(private repository: RepositoryService, private router: Router, 
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

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

  public redirectToUpdatePage = (WrittenOfStockId) => { 
    const updateUrl: string = '/writtenoffstock/update/' + WrittenOfStockId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (WrittenOfStockId) => { 
    const deleteUrl: string = '/writtenoffstock/delete/' + WrittenOfStockId; 
    this.router.navigate([deleteUrl]); 
  }

}
