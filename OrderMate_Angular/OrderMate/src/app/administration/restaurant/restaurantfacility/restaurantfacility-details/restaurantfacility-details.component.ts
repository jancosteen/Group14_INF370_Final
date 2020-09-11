import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../../shared/services/error-handler.service';


import {RestaurantFacility} from '../../../../_interfaces/Administration/RestaurantFacility/restaurantfacility.model'

@Component({
  selector: 'app-restaurantfacility-details',
  templateUrl: './restaurantfacility-details.component.html',
  styleUrls: ['./restaurantfacility-details.component.css'
]
}) 
export class RestaurantfacilityDetailsComponent implements OnInit {

  public restaurantfacility: RestaurantFacility;
  public errorMessage: string = '';

  constructor(private repository: RepositoryService, private router: Router, 
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getRestaurantFacilityDetails();
  }


  getRestaurantFacilityDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    //console.log('id',id);
    let apiUrl: string = 'api/restaurantfacility/'+id;
 
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.restaurantfacility = res as RestaurantFacility;
    },
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }


  public redirectToUpdatePage = (restaurantfacilityId) => { 
    const updateUrl: string = '/restaurantfacility/update/' + restaurantfacilityId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = () => { 
    const deleteUrl: string = '/restaurantfacility/list'; 
    this.router.navigate([deleteUrl]); 
  }

}
