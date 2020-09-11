import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';

import {Seating} from '../../../_interfaces/Order/Seating/seating.model'

@Component({
  selector: 'app-seating-details',
  templateUrl: './seating-details.component.html', 
  styleUrls: ['./seating-details.component.css']
})
export class SeatingDetailsComponent implements OnInit {
  public seating: Seating; 
  public errorMessage: string = ''; 

  constructor(private repository: RepositoryService, private router: Router,  
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void { 
    this.getDetails();
  }

  getDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    //console.log('id',id);
    let apiUrl: string = 'api/seating/'+id;
 
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.seating = res as Seating;
    },
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }
  public redirectToUpdatePage = (seatingId) => { 
    const updateUrl: string = '/seating/update/' + seatingId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (seatingId) => { 
    const deleteUrl: string = '/seating/delete/' + seatingId; 
    this.router.navigate([deleteUrl]); 
  }


}
 