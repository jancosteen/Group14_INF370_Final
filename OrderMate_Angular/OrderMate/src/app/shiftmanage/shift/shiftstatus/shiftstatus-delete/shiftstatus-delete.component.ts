import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router'; 

import {ShiftStatus} from 'src/app/_interfaces/EmployeeManage/ShiftStatus/shiftstatus.model';

@Component({
  selector: 'app-shiftstatus-delete',
  templateUrl: './shiftstatus-delete.component.html',
  styleUrls: ['./shiftstatus-delete.component.css']
})
export class ShiftstatusDeleteComponent implements OnInit {

  public errorMessage: string = '';
  public shiftstatus: ShiftStatus; 
  

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

    ngOnInit(): void { 
      this.getshiftstatusDetails(); 
    }
  
  
    getshiftstatusDetails = () => {
      let id: string = this.activeRoute.snapshot.params['id'];
      
      let apiUrl: string = 'api/shiftstatus/'+id;
   
      this.repository.getData(apiUrl)
      .subscribe(res => {
        this.shiftstatus = res as ShiftStatus;
      },
      (error) =>{
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    }


    public deleteshiftstatus = () => {
      const deleteUrl: string = 'api/shiftstatus/' + this.shiftstatus.shiftstatusId ;

      this.repository.delete(deleteUrl)
        .subscribe(res => {
   
          $('#successModal').modal();
        },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        })
    }

    public redirectToshiftstatusList(){
      this.router.navigate(['/shiftstatus/list']);
    }

}
