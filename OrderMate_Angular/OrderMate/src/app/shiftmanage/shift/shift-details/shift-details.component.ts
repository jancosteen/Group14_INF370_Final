import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service'; 

import {Shift} from 'src/app/_interfaces/EmployeeManage/Shift/shift.model';

@Component({
  selector: 'app-shift-details',
  templateUrl: './shift-details.component.html',
  styleUrls: ['./shift-details.component.css']
})
export class ShiftDetailsComponent implements OnInit {
  public shift: Shift;
  public errorMessage: string = '';

  constructor(private repository: RepositoryService, private router: Router, 
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getShiftDetails();
  }


  getShiftDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    //console.log('id',id);
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

  public redirectToUpdatePage = (shiftId) => { 
    const updateUrl: string = '/shift/update/' + shiftId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (shiftId) => { 
    const deleteUrl: string = '/shift/delete/' + shiftId; 
    this.router.navigate([deleteUrl]); 
  }
 
}
