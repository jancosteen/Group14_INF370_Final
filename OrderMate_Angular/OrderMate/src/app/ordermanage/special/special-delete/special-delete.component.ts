import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';  

import {Special} from '../../../_interfaces/Order/Special/special.model';

@Component({
  selector: 'app-special-delete', 
  templateUrl: './special-delete.component.html',
  styleUrls: ['./special-delete.component.css']
})
export class SpecialDeleteComponent implements OnInit {

  public errorMessage: string = '';
  public special: Special; 
  

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

    ngOnInit(): void {
      this.getDetails(); 
    }
  
  
    getDetails = () => {
      let id: string = this.activeRoute.snapshot.params['id'];
      
      let apiUrl: string = 'api/special/'+id;
   
      this.repository.getData(apiUrl)
      .subscribe(res => {
        this.special = res as Special;
      },
      (error) =>{
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    }


    public delete = () => {
      const deleteUrl: string = 'api/special/' + this.special.specialId ;

      this.repository.delete(deleteUrl)
        .subscribe(res => {
   
          $('#successModal').modal();
        },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage; 
        })
    }

    public redirectTospecialList(){
      this.router.navigate(['/special/list']);
    }

}
