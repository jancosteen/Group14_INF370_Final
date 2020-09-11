import { Component, OnInit } from '@angular/core';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { Reservation } from 'src/app/_interfaces/reservation.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';

@Component({
  selector: 'app-reservation-list',
  templateUrl: './reservation-list.page.html',
  styleUrls: ['./reservation-list.page.scss'],
})
export class ReservationListPage implements OnInit {

  reservations: Reservation[];
  userId:string;
  public errorMessage: string = '';

  constructor(private repository: RepositoryService
    ,private authService:AuthenticationService,
    private errorHandler: ErrorHandlerService) { }

  ngOnInit() {
    this.getReservations();
  }

  getReservations(){
    this.userId = localStorage.getItem('userId');

    const apiUrl= `api/reservation/${this.userId}/userId`;
    
      this.repository.getData(apiUrl)
      .subscribe(res => {
        this.reservations = res as Reservation[];
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    }
    
    
  

  logout() {
    this.authService.logout();
  }

}
