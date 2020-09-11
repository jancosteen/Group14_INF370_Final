import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router'; 


import {Shift} from 'src/app/_interfaces/EmployeeManage/Shift/shift.model';

@Component({
  selector: 'app-shift-delete',
  templateUrl: './shift-delete.component.html',
  styleUrls: ['./shift-delete.component.css']
})
export class ShiftDeleteComponent implements OnInit {

  public errorMessage: string = '';
  public shift: Shift; 
  

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

    ngOnInit(): void { 
      this.getshiftDetails(); 
    }
  
  
    getshiftDetails = () => {
      let id: string = this.activeRoute.snapshot.params['id'];
      
      let apiUrl: string = 'api/shift/'+id;
   
      this.repository.getData(apiUrl)
      .subscribe(res => {
        this.shift = res as Shift;
      },
      (error) =>{
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    }


    public deleteshift = () => {
      const deleteUrl: string = 'api/shift/' + this.shift.shiftId ;

      this.repository.delete(deleteUrl)
        .subscribe(res => {
   
          $('#successModal').modal();
        },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        })
    }

    public redirectToshiftList(){
      this.router.navigate(['/shift/list']);
    }


}
