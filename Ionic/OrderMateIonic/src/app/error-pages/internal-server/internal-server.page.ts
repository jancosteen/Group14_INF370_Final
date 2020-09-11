import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-internal-server',
  templateUrl: './internal-server.page.html',
  styleUrls: ['./internal-server.page.scss'],
})
export class InternalServerPage implements OnInit {
  public errorMessage: string = "500 SERVER ERROR, CONTACT ADMINISTRATOR!!!!";

  constructor() { }

  ngOnInit() {
  }

}
