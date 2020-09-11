import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { ErrorHandlerService } from '../../../shared/services/error-handler.service';
import { RepositoryService } from '../../../shared/services/repository.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';

import {Shift} from 'src/app/_interfaces/EmployeeManage/Shift/shift.model'; 

@Component({
  selector: 'app-shift-list',
  templateUrl: './shift-list.component.html',
  styleUrls: ['./shift-list.component.css']
})
export class ShiftListComponent implements OnDestroy, OnInit {

  public shifts: Shift[];

  public errorMessage: string = '';
  dtTrigger: Subject<any>  =  new Subject();
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective;
  min:number;
  max:number;

  constructor(private repository :  RepositoryService, private errorHandler: ErrorHandlerService, 
    private router: Router) { }

    dtOptions: DataTables.Settings = {};

    ngOnInit(): void {
   
      this.dtOptions = {
        pagingType: 'full_numbers',
        pageLength: 5
      };
        let apiAddress: string = "api/shift";
        this.repository.getData(apiAddress)
        .subscribe(res => {
          this.shifts = res as Shift[];
          
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
  
  
    ngOnDestroy(): void {
      this.dtTrigger.unsubscribe();
      $.fn.dataTable.ext.errMode = 'throw';
    }


    public getDetails = (shiftId) => { 
      const detailsUrl: string = '/shift/details/' + shiftId; 
      this.router.navigate([detailsUrl]); 
    }
    
    public redirectToUpdatePage = (shiftId) => { 
      const updateUrl: string = '/shift/details/' + shiftId; 
      this.router.navigate([updateUrl]); 
    }
  
    public redirectToDeletePage = (shiftId) => { 
      const deleteUrl: string = '/shift/details/' + shiftId; 
      this.router.navigate([deleteUrl]);  
    }

}
