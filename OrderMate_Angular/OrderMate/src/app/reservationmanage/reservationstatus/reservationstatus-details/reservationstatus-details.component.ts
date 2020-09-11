import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from '../../../shared/services/repository.service';
import { ErrorHandlerService } from '../../../shared/services/error-handler.service'; 

import {ReservationStatus} from '../../../_interfaces/Reservationmanage/ReservationStatus/reservationstatus.model'

@Component({ 
  selector: 'app-reservationstatus-details',
  templateUrl: './reservationstatus-details.component.html',
  styleUrls: ['./reservationstatus-details.component.css']
})
export class ReservationstatusDetailsComponent implements OnInit {

  public reservationStatus: ReservationStatus;
  public errorMessage: string = '';

  constructor(private repository: RepositoryService, private router: Router, 
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getDetails();
  }

  getDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    //console.log('id',id);
    let apiUrl: string = 'api/reservationstatus'+id;
 
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.reservationStatus = res as ReservationStatus;
    },
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }

  public redirectToUpdatePage = (reservationStatusId) => { 
    const updateUrl: string = '/reservationstatus/update' + reservationStatusId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (reservationStatusId) => { 
    const deleteUrl: string = '/reservationstatus/delete' + reservationStatusId; 
    this.router.navigate([deleteUrl]); 
  }
}
