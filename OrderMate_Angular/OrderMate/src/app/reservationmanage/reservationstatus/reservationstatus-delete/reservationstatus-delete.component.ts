import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';  

import {ReservationStatus} from '../../../_interfaces/Reservationmanage/ReservationStatus/reservationstatus.model'

@Component({
  selector: 'app-reservationstatus-delete',
  templateUrl: './reservationstatus-delete.component.html',
  styleUrls: ['./reservationstatus-delete.component.css']
})
export class ReservationstatusDeleteComponent implements OnInit {

  public errorMessage: string = '';
  public reservationStatus: ReservationStatus; 
  

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

    ngOnInit(): void {
      this.getDetails(); 
    }
   
  
    getDetails = () => {
      let id: string = this.activeRoute.snapshot.params['id'];
      
      let apiUrl: string = 'api/reservationstatus/'+id;
   
      this.repository.getData(apiUrl)
      .subscribe(res => {
        this.reservationStatus = res as ReservationStatus;
      },
      (error) =>{
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    }


    public delete = () => {
      const deleteUrl: string = 'api/reservationstatus/' + this.reservationStatus.reservationStatusId ;

      this.repository.delete(deleteUrl)
        .subscribe(res => {
   
          $('#successModal').modal();
        },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        })
    }

    public redirectToList(){
      this.router.navigate(['/reservationstatus/list']);
    }

}
