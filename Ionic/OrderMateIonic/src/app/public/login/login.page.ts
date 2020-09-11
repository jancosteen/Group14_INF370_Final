import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from './../../services/authentication.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { NavController } from '@ionic/angular';


@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {

  constructor(
    private nav: NavController
   ) { }

  ngOnInit() {
  }
  
  openLoginModal(){
    this.nav.navigateRoot('login-modal');
  }

}
