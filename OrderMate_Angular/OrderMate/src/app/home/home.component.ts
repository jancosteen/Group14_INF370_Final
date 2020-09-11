import { UsermanageComponent } from './../usermanage/usermanage.component';
import { CurrentUser } from './../shared/services/data-types';
import { Component, OnInit, Output, EventEmitter, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { RepositoryService } from '../shared/services/repository.service';
import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit, OnDestroy {
  mobileQuery: MediaQueryList;
  userDetails;
  userName: string ='';
  userRole: string = '';

  @Output() public sidenavToggle = new EventEmitter()
  public homeText: string;
  private _mobileQueryListener: () => void;

  constructor(
    changeDetectorRef: ChangeDetectorRef,
    media: MediaMatcher,
    private router: Router,
    private repository: RepositoryService,
    private jwt: JwtHelperService) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
  }

  ngOnInit() {
    console.log('this is home')
    this.repository.getUserProfile(this.repository.currentUser.userName).subscribe(
      res => {
        this.userDetails = res;
        this.userName = this.userDetails.userName;
        this.userRole = this.userDetails.userRole;
       
      },
      err => {
        console.log(err);
      },
    );
    


  }




  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }

  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

  public onToggleSidenav = () => {
    this.sidenavToggle.emit();
  }

}
