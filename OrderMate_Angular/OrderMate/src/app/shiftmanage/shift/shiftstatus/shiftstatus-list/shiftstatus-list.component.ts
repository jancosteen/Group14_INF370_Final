import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { ErrorHandlerService } from '../../../../shared/services/error-handler.service';
import { RepositoryService } from '../../../../shared/services/repository.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';

import {ShiftStatus} from 'src/app/_interfaces/EmployeeManage/ShiftStatus/shiftstatus.model' 

@Component({
  selector: 'app-shiftstatus-list',
  templateUrl: './shiftstatus-list.component.html',
  styleUrls: ['./shiftstatus-list.component.css']
})
export class ShiftstatusListComponent implements OnDestroy, OnInit {

  public shiftstatus: ShiftStatus[];

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
        let apiAddress: string = "api/shiftstatus";
        this.repository.getData(apiAddress)
        .subscribe(res => {
          this.shiftstatus = res as ShiftStatus[];
          
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





  public getProductDetails = (shiftstatusId) => { 
    const detailsUrl: string = '/shiftstatus/details/' + shiftstatusId; 
    this.router.navigate([detailsUrl]); 
  }
  
  public redirectToUpdatePage = (shiftstatusId) => { 
    const updateUrl: string = '/shiftstatus/details/' + shiftstatusId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (shiftstatusId) => { 
    const deleteUrl: string = '/shiftstatus/details/' + shiftstatusId; 
    this.router.navigate([deleteUrl]);  
  }

}
