import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';

import { StockTake} from 'src/app/_interfaces/Product/StockTake/stocktake.model'; 


@Component({
  selector: 'app-stocktake-details',
  templateUrl: './stocktake-details.component.html',
  styleUrls: ['./stocktake-details.component.css']
})
export class StocktakeDetailsComponent implements OnInit {

  public errorMessage: string = '';
 
  public Stocktake: StockTake;

  constructor(private repository: RepositoryService, private router: Router, 
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getStockTakeDetails();
  }

  getStockTakeDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    //console.log('id',id);
    let apiUrl: string = 'api/StockTake/'+id;
 
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.Stocktake = res as StockTake;
    },
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }

  public redirectToUpdatePage = (stocktakeId) => { 
    const updateUrl: string = '/stocktake/update/' + stocktakeId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (stocktakeId) => { 
    const deleteUrl: string = '/stocktake/delete/' + stocktakeId; 
    this.router.navigate([deleteUrl]); 
  }


}
