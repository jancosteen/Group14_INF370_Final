import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';

import {SpecialPrice} from '../../../_interfaces/Order/SpecialPrice/specialprice.model';

@Component({
  selector: 'app-specialprice-details',
  templateUrl: './specialprice-details.component.html',
  styleUrls: ['./specialprice-details.component.css']
})
export class SpecialpriceDetailsComponent implements OnInit {
  public specialPrice: SpecialPrice;
  public errorMessage: string = ''; 

  constructor(private repository: RepositoryService, private router: Router, 
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getDetails();
  }

  
  getDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    //console.log('id',id);
    let apiUrl: string = 'api/specialprice/'+id;
 
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.specialPrice = res as SpecialPrice; 
    },
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }

  public redirectToUpdatePage = (specialPriceId) => { 
    const updateUrl: string = '/specialprice/update/' + specialPriceId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (specialPriceId) => { 
    const deleteUrl: string = '/specialprice/delete/' + specialPriceId; 
    this.router.navigate([deleteUrl]); 
  }

}
