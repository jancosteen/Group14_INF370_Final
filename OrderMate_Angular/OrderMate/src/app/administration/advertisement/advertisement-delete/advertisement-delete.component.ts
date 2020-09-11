import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from '../../../shared/services/error-handler.service';
import { RepositoryService } from '../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router'; 

import {Advertisement} from '../../../_interfaces/Administration/Advertisements/advertisement.model'

@Component({
  selector: 'app-advertisement-delete',
  templateUrl: './advertisement-delete.component.html',
  styleUrls: ['./advertisement-delete.component.css']
})
export class AdvertisementDeleteComponent implements OnInit {

  public errorMessage: string = '';
  public advertisement: Advertisement; 
  

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

    ngOnInit(): void {
      this.getDetails(); 
    }

    getDetails = () => {
      let id: string = this.activeRoute.snapshot.params['id'];
      
      let apiUrl: string = 'api/advertisement/'+id;
   
      this.repository.getData(apiUrl)
      .subscribe(res => {
        this.advertisement = res as Advertisement;
      },
      (error) =>{
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    }

    public delete = () => {
      const deleteUrl: string = 'api/advertisement/' + this.advertisement.advertisementId ;

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
      this.router.navigate(['/advertisement/list']);
    }

}
