import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../../shared/services/error-handler.service';


import {ShiftStatus} from 'src/app/_interfaces/EmployeeManage/ShiftStatus/shiftstatus.model';

@Component({
  selector: 'app-shiftstatus-details',
  templateUrl: './shiftstatus-details.component.html',
  styleUrls: ['./shiftstatus-details.component.css']
})
export class ShiftstatusDetailsComponent implements OnInit {

  public shiftstatus: ShiftStatus;
  public errorMessage: string = '';

  constructor(private repository: RepositoryService, private router: Router, 
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getShiftStatusDetails();
  }


  getShiftStatusDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    //console.log('id',id);
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

  public redirectToUpdatePage = (shiftstatusId) => { 
    const updateUrl: string = '/shiftstatus/update/' + shiftstatusId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (shiftstatusId) => { 
    const deleteUrl: string = '/shiftstatus/delete/' + shiftstatusId; 
    this.router.navigate([deleteUrl]); 
  }

}
