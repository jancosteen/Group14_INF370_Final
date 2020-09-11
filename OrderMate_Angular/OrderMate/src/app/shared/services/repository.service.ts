import { CurrentUser } from './data-types';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'; 
import { EnvironmentUrlService } from './environment-url.service';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { tokenGetter } from 'src/app/app.module';
import { JwtHelperService } from '@auth0/angular-jwt';
 
@Injectable({
  providedIn: 'root'
})
export class RepositoryService {

  constructor(private http: HttpClient,private envUrl: EnvironmentUrlService){}

  getUserProfile(userName){
    
    return this.http.get(this.createCompleteRoute("api/user/profile"+"/"+userName,this.envUrl.urlAddress));
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

  
  register(body){
    
    return this.http.post(this.createCompleteRoute("api/user/register",this.envUrl.urlAddress),body,this.generateHeaders());
  }
  public 

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


