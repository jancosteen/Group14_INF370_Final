import { CurrentUser } from './data-types';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'; 
import { EnvironmentUrlService } from './environment-url.service';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { tokenGetter } from 'src/app/app.module';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router, ActivatedRoute } from '@angular/router';
 
@Injectable({
  providedIn: 'root'
})
export class RepositoryService {

  constructor(private http: HttpClient,private envUrl: EnvironmentUrlService,
    private activeRoute: ActivatedRoute){}

  

  getUserProfile(userName){
    
    return this.http.get(this.createCompleteRoute("api/user/profile"+"/"+userName,this.envUrl.urlAddress));
  }
  public getOrdersBetween(dateFrom,dateTo){
    return this.http.get(this.createCompleteRoute("api/reporting/ordersBetween/" +dateFrom+'/'+dateTo,this.envUrl.urlAddress));
  }
  public getSalesbyRestaurant(restaurantId,dateFrom,dateTo){
    return this.http.get(this.createCompleteRoute("api/reporting/salesRestaurant/"+restaurantId+'/' +dateFrom+'/'+dateTo,this.envUrl.urlAddress));
  }
  public getSupplierReport(dateFrom,dateTo,supplierId){
    return this.http.get(this.createCompleteRoute("api/reporting/supplierOrder/" +dateFrom+'/'+dateTo+'/' +supplierId,this.envUrl.urlAddress));
  }

  public getSalesbyMenuItem(menuItemId,dateFrom,dateTo){
    console.log('menuItem',menuItemId)
    console.log('from',dateFrom)
    console.log('to',dateTo)
    return this.http.get(this.createCompleteRoute("api/reporting/salesByMenuItem/"+menuItemId+'/'+dateFrom+'/'+dateTo,this.envUrl.urlAddress));
  }
  
  login(data){
    return this.http.post(this.createCompleteRoute("api/user/login",this.envUrl.urlAddress),data);
  }

  get currentUser(){
    let token = localStorage.getItem('token');
  
    if(!token) return null;

    const helper = new JwtHelperService();
    return helper.decodeToken(token) as CurrentUser;
    
  }

  getMenuId(id){
    let menuId : number =  id
  }

  
  register(body){
    
    return this.http.post(this.createCompleteRoute("api/user/register",this.envUrl.urlAddress),body,this.generateHeaders());
  }
  

  public signin = (route: string, body) =>{
    return this.http.post(this.createCompleteRoute(route, this.envUrl.urlAddress), body, this.generateHeaders());
  }

  public getData = (route: string) => {
    return this.http.get(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  
 
  public create = (route: string, body) => {
    return this.http.post(this.createCompleteRoute(route, this.envUrl.urlAddress), body, this.generateHeaders());
  }
 
  public update = (route: string, body) => {
    return this.http.put(this.createCompleteRoute(route, this.envUrl.urlAddress), body, this.generateHeaders());
  }
 
  public delete = (route: string) => {
    return this.http.delete(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }
 
  private createCompleteRoute = (route: string, envAddress: string) => {
   // console.log('address',envAddress + '/' + route);
    return envAddress + '/' + route;
  }
 
  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }
  }
}


