import { Component, OnInit, OnDestroy, ViewChild, NgModule  } from '@angular/core';
import { RepositoryService } from './../../shared/services/repository.service';
import { ErrorHandlerService } from './../../shared/services/error-handler.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';


import {Menu} from '../../_interfaces/menumange/Menu/menu.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css'],

})


export class MenuComponent implements OnInit {
  public menu: Menu[];
  public errorMessage: string = '';

  constructor(private repository :  RepositoryService, private errorHandler: ErrorHandlerService, 
    private router: Router) { }


    
  ngOnInit(): void {
    let apiAddress: string = "api/menu";
      this.repository.getData(apiAddress)
      .subscribe(res => {
        this.menu = res as Menu[];
        console.log('dilo tse', this.menu)
      });

  } 

  public redirectToItemsPage = (menuId) => { 
    const updateUrl: string = '/menuitems/' + menuId; 
    this.router.navigate([updateUrl]); 
  }

}
