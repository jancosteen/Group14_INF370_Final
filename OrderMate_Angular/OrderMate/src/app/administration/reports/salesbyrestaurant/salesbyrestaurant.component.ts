import { SalesbyRestaurant } from './../../../_interfaces/Administration/Reports/salesbyrestaurant.model';
import { Restaurant } from './../../../_interfaces/Administration/Restaurant/restaurant.model';
import { ToastrService } from 'ngx-toastr';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { RepositoryService } from '../../../shared/services/repository.service';
import { Component, OnInit } from '@angular/core';
import { jsPDF } from "jspdf";
import  html2canvas from 'html2canvas';  
import autoTable from 'jspdf-autotable';


@Component({
  selector: 'app-salesbyrestaurant',
  templateUrl: './salesbyrestaurant.component.html',
  styleUrls: ['./salesbyrestaurant.component.css']
})
export class SalesbyrestaurantComponent implements OnInit {
  salesbyRestaurantForm: FormGroup;
  selectedRestaurant: Restaurant;

  constructor(private repository: RepositoryService, private toast : ToastrService) { }

  ngOnInit(): void {
    this.getMenuItem();
    this.salesbyRestaurantForm = new FormGroup({
      restaurantId: new FormControl(''),
      dateFrom: new FormControl('',[Validators.required]),
      dateTo: new FormControl('',[Validators.required]),
    });
  }

  public validateControl = (controlName: string) => {
    if (this.salesbyRestaurantForm.controls[controlName].invalid && this.salesbyRestaurantForm.controls[controlName].touched)
      return true;
  
    return false;
  }
  
  public hasError = (controlName: string, errorName: string) => {
    if (this.salesbyRestaurantForm.controls[controlName].hasError(errorName))
      return true;
  
    return false;
  }
  restaurants: Restaurant[];

  getMenuItem(){
    let Address: string = "api/restaurant";
    this.repository.getData(Address)
    .subscribe(res => {
      this.restaurants = res as Restaurant[];
    })  
  }
  stuff:SalesbyRestaurant[]
  list: SalesbyRestaurant[]
  report(value){
    
    
    let id: number

    this.restaurants.forEach(item =>{
      if(value.restaurantId == item.restaurantName){
        console.log('ke item ',item.restaurantId)
        id = item.restaurantId
      } 
    })
    this.list =[];
    this.repository.getSalesbyRestaurant(id,value.dateFrom,value.dateTo) 
      .subscribe(res =>{
        this.stuff = res as SalesbyRestaurant[]
        if(res == null){
          this.toast.info('No Content','Report Retrieval Failed.');
        }
        
    
        this.stuff.forEach(stuf =>{
      
          this.restaurants.forEach(res => {
            if(res.restaurantId == stuf.restaurant_Id){
              stuf.restaurantName ==res.restaurantName
             
              this.list.push(stuf)
              this.toast.success('Yebo!!','Its a success!!!')
            }
          })
        })
        
      },
      err =>{
        this.toast.error('No content','Report Retrieval Failed.');
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
      pdf.text("Sales by Restaurant",80,20);
     // autoTable(pdf, {html: '#menuItemsTable'})
      pdf.addImage(contentDataUrl,'PNG',40,60,imgWidth,imgHeight)
      pdf.text('Thank you',90,200)
      pdf.save('SalesbyRestaurant.pdf');
    });
        
  }
 
}
