import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';  

import {Seating} from '../../../_interfaces/Order/Seating/seating.model'

@Component({
  selector: 'app-seating-delete',
  templateUrl: './seating-delete.component.html',
  styleUrls: ['./seating-delete.component.css']
})
export class SeatingDeleteComponent implements OnInit {
  public errorMessage: string = '';
  public seating: Seating; 
  

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

    ngOnInit(): void {
      this.getDetails(); 
    }
  
  
    getDetails = () => {
      let id: string = this.activeRoute.snapshot.params['id'];
      
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

    public delete = () => {
      const deleteUrl: string = 'api/seating/' + this.seating.seatingId ;

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
    this.router.navigate(['/seating/list']);
  }


}
