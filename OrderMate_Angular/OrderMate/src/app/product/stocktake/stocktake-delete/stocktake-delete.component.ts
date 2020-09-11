import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router'; 


import { StockTake} from 'src/app/_interfaces/Product/StockTake/stocktake.model'; 

@Component({
  selector: 'app-stocktake-delete',
  templateUrl: './stocktake-delete.component.html',
  styleUrls: ['./stocktake-delete.component.css']
})
export class StocktakeDeleteComponent implements OnInit {
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

  public deleteStockTake = () => {
    const deleteUrl: string = 'api/Stocktake/' + this.Stocktake.stocktakeId ;

    this.repository.delete(deleteUrl)
      .subscribe(res => {
 
        $('#successModal').modal();
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage; 
      })
  }

  public redirectToStockTakeList(){
    this.router.navigate(['/Stocktake/list']);
  }

}
