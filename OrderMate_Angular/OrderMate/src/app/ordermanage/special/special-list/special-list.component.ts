import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';


import {Special} from 'src/app/_interfaces/Order/Special/special.model'

@Component({
  selector: 'app-special-list',
  templateUrl: './special-list.component.html',
  styleUrls: ['./special-list.component.css']
})
export class SpecialListComponent implements OnDestroy, OnInit {
  public specials: Special[];
  public errorMessage: string = '';
  public x:string;
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
      let apiAddress: string = "api/special";
      this.repository.getData(apiAddress)
      .subscribe(res => {
        this.specials = res as Special[];
        
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

  public getAllSpecials = () => {
    let apiAddress: string = "api/special";
    this.repository.getData(apiAddress)
    .subscribe(res => {
   //   this.dataSource.data = res as Supplier[];
     this.specials = res as Special[];
    //this.dtTrigger.next(); 
    
    },
    (error) => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
      
  }


  public getDetailsPage = (specialId) => { 
    const detailsUrl: string = '/special/details/' + specialId; 
    this.router.navigate([detailsUrl]); 
  }
  
  public redirectToUpdatePage = (specialId) => { 
    const updateUrl: string = '/special/update/' + specialId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (specialId) => { 
    const deleteUrl: string = '/special/delete/' + specialId; 
    this.router.navigate([deleteUrl]); 
  }

}
