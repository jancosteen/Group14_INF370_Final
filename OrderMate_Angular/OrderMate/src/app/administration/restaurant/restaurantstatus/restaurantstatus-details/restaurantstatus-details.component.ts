import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../../shared/services/error-handler.service';

import {RestaurantStatus} from 'src/app/_interfaces/Administration/RestaurantStatus/restaurantstatus.model';
 


@Component({
  selector: 'app-restaurantstatus-details',
  templateUrl: './restaurantstatus-details.component.html',
  styleUrls: ['./restaurantstatus-details.component.css']
})
export class RestaurantstatusDetailsComponent implements OnInit {

  public restaurantStatus: RestaurantStatus;
  public errorMessage: string = '';

  constructor(private repository: RepositoryService, private router: Router, 
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getRestaurantStatusDetails();
  }


  getRestaurantStatusDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    //console.log('id',id);
    let apiUrl: string = 'api/restaurantstatus/'+id;
 
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.restaurantStatus = res as RestaurantStatus;
    },
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }




  public redirectToUpdatePage = (restaurantstatusId) => { 
    const updateUrl: string = '/restaurantstatus/update/' + restaurantstatusId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (restaurantstatusId) => { 
    const deleteUrl: string = '/restaurantstatus/delete/' + restaurantstatusId; 
    this.router.navigate([deleteUrl]); 
  }

}
