import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from '../../../../shared/services/error-handler.service';
import { RepositoryService } from '../../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router'; 
 

import {RestaurantStatus} from 'src/app/_interfaces/Administration/RestaurantStatus/restaurantstatus.model';


@Component({
  selector: 'app-restaurantstatus-delete',
  templateUrl: './restaurantstatus-delete.component.html',
  styleUrls: ['./restaurantstatus-delete.component.css']
})
export class RestaurantstatusDeleteComponent implements OnInit {
  public errorMessage: string = '';
  public restaurantstatus: RestaurantStatus; 
  

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

    ngOnInit(): void {
      this.getRestaurantStatusDetails(); 
    }

    getRestaurantStatusDetails = () => {
      let id: string = this.activeRoute.snapshot.params['id'];
      
      let apiUrl: string = 'api/restaurantstatus/'+id;
   
      this.repository.getData(apiUrl)
      .subscribe(res => {
        this.restaurantstatus = res as RestaurantStatus;
      },
      (error) =>{
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    }

    public deleteRestaurantStatus = () => {
      const deleteUrl: string = 'api/restaurantstatus/' + this.restaurantstatus.restaurantstatusId ;

      this.repository.delete(deleteUrl)
        .subscribe(res => {
   
          $('#successModal').modal();
        },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        })
    }

    public redirectToRestaurantStatusList(){
      this.router.navigate(['/restaurantstatus/list']);
    }

  

}
