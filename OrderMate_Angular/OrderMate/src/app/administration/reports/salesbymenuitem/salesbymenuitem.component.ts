import { Order } from './../../../_interfaces/Order/Order/order.model';
import { SalesByMenuItem, ReturnedSalesByMenuItem } from './../../../_interfaces/Administration/Reports/salesbymenuitem.model';
import { MenuItem } from './../../../_interfaces/menumange/MenuItem/menuitem.model';
import { Component, OnInit } from '@angular/core';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { SalesbyRestaurant } from 'src/app/_interfaces/Administration/Reports/salesbyrestaurant.model';
import { jsPDF } from "jspdf";
import  html2canvas from 'html2canvas';  
import autoTable from 'jspdf-autotable';


@Component({
  selector: 'app-salesbymenuitem',
  templateUrl: './salesbymenuitem.component.html',
  styleUrls: ['./salesbymenuitem.component.css']
})
export class SalesbymenuitemComponent implements OnInit {
  menuitems: MenuItem[];
  selectedItem: MenuItem;
  public salesbyMenuItemForm: FormGroup; 
  object : SalesByMenuItem;
  selectedMenuItem: MenuItem;

  constructor(private repository :  RepositoryService,
    private toast: ToastrService) { }

  ngOnInit(): void {
    this.getMenuItem();
    this.salesbyMenuItemForm = new FormGroup({
      menuItemId: new FormControl(''),
      dateFrom: new FormControl('',[Validators.required]),
      dateTo: new FormControl('',[Validators.required]),
    }); 
  }
  public validateControl = (controlName: string) => {
    if (this.salesbyMenuItemForm.controls[controlName].invalid && this.salesbyMenuItemForm.controls[controlName].touched)
      return true;
  
    return false;
  }
  
  public hasError = (controlName: string, errorName: string) => {
    if (this.salesbyMenuItemForm.controls[controlName].hasError(errorName))
      return true;
  
    return false;
  }

  getMenuItem(){
    let Address: string = "api/menuitem";
    this.repository.getData(Address)
    .subscribe(res => {
      this.menuitems = res as MenuItem[];
    })  
  }
  stuff: ReturnedSalesByMenuItem[];
  returnedSalesByMenuItem: ReturnedSalesByMenuItem[];


  report(value){
    
    let id: string
    console.log('di items',this.menuitems)
    this.menuitems.forEach(item =>{
      if(value.menuItemId == item.menuItemName){
        console.log('ke item ',item.menuItemId)
        id = item.menuItemId
      } 
    })
 
    this.repository.getSalesbyMenuItem(id,value.dateFrom,value.dateTo) 
      .subscribe(res =>{
        if(res == null){
          this.toast.info('No Content','Report Retrieval Failed.');
        }
        

        this.stuff = res as ReturnedSalesByMenuItem[]
        this.toast.success('Yebo!!','Its a success!!!')
      },
      err =>{
        this.toast.error('Said item was sold between these two Dates.','Report Retrieval Failed.');
      })
  }


  DownloadReport(){
   
    var data = document.getElementById('Content');
    html2canvas(data).then(canvas => {
      var imgWidth = 208;
      var pageHeight = 295;
      var imgHeight = canvas.height * imgWidth /canvas.width;
      var heightLeft = imgHeight;

      const contentDataUrl = canvas.toDataURL('image/png')
      let pdf = new jsPDF('p','mm','a4');
      
      var position = 0;
      pdf.text("Sales by MenuItem",80,20);
   
      pdf.addImage(contentDataUrl,'PNG',40,60,imgWidth,imgHeight)
      pdf.text('Thank you',90,200)
      pdf.save('SalesbyMenuItem.pdf');
    });
        
  }

} 
