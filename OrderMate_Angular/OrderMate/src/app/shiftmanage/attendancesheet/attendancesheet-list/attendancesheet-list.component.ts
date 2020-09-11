import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { RepositoryService } from '../../../shared/services/repository.service';
import { ErrorHandlerService } from '../../../shared/services/error-handler.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';

import {AttendanceSheet} from 'src/app/_interfaces/EmployeeManage/AttendenceSheet/attendancesheet.model';

@Component({
  selector: 'app-attendancesheet-list',
  templateUrl: './attendancesheet-list.component.html',
  styleUrls: ['./attendancesheet-list.component.css']
})
export class AttendancesheetListComponent implements OnDestroy, OnInit {
  public attendancesheet: AttendanceSheet[];
  public errorMessage: string = '';
  dtTrigger: Subject<any>  =  new Subject();
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective;
  min:number;
  max:number;
  public currentlyloggedinuserId:string ='5';

  constructor(private repository :  RepositoryService, private errorHandler: ErrorHandlerService, 
    private router: Router) { }

    dtOptions: DataTables.Settings = {};

    ngOnInit(): void {
   
      this.dtOptions = {
        pagingType: 'full_numbers',
        pageLength: 5
      };
      let apiAddress: string = "api/attendancesheet";
        this.repository.getData(apiAddress)
        .subscribe(res => {
          this.attendancesheet = res as AttendanceSheet[];
          
          this.dtTrigger.next();
        });     
  
        $.fn['dataTable'].ext.search.push((settings, data, dataIndex) => {
        const id = parseFloat(data[0]) || 0; // use data for the id column
        if ((isNaN(this.min) && isNaN(this.max)) ||
          (isNaN(this.min) && id <= this.max) ||
          (this.min <= id && isNaN(this.max)) ||
          (this.min <= id && id <= this.max)) {
          return true;
        }
        return false;
      });
  
    }

    //ToDo fetch all employees that belong to a certain employee
    private getemployeeshifts(currentlyloggedinuserId){
      let apiAddress: string = "api/attendancesheet" + currentlyloggedinuserId;
        this.repository.getData(apiAddress)
        .subscribe(res => {
          this.attendancesheet = res as AttendanceSheet[];
          
          this.dtTrigger.next();
        });
    }
    //ToDo Clock In
    public clockIn(attendancesheet){

    }
    //ToDo clock out
    public ClockOut(attendancesheet){
      
    }
  
    ngOnDestroy(): void {
      this.dtTrigger.unsubscribe();
      $.fn.dataTable.ext.errMode = 'throw';
    }

  




}
