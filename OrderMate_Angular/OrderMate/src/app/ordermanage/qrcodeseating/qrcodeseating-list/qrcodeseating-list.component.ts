import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { ErrorHandlerService } from '../../../shared/services/error-handler.service';
import { RepositoryService } from '../../../shared/services/repository.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs'; 

import {QrCodeSeating} from '../../../_interfaces/Order/QRCodeSeating/qrcodeseating.model'

@Component({
  selector: 'app-qrcodeseating-list',
  templateUrl: './qrcodeseating-list.component.html',
  styleUrls: ['./qrcodeseating-list.component.css']
})
export class QrcodeseatingListComponent implements OnInit, OnDestroy {

  public qrCodeSeating: QrCodeSeating[];

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
        let apiAddress: string = "api/qrcodeseating";
        this.repository.getData(apiAddress)
        .subscribe(res => {
          this.qrCodeSeating = res as QrCodeSeating[];
          
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

    public getDetailsPage = (qrCodeSeatingId) => { 
      const detailsUrl: string = '/qrcodeseating/details/' + qrCodeSeatingId; 
      this.router.navigate([detailsUrl]); 
    }
    
    public redirectToUpdatePage = (qrCodeSeatingId) => { 
      const updateUrl: string = '/qrcodeseating/details/' + qrCodeSeatingId; 
      this.router.navigate([updateUrl]); 
    }
  
    public redirectToDeletePage = (qrCodeSeatingId) => { 
      const deleteUrl: string = '/qrcodeseating/details/' + qrCodeSeatingId; 
      this.router.navigate([deleteUrl]);   
    }

}
