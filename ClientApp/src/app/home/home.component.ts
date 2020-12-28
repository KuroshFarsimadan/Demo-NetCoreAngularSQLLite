import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
    title = 'Home Component';
    showRegistration = false;
    users: any;

    constructor(private http: HttpClient) {

    }

    toggleRegistration() {
      this.showRegistration = true;
    }
    cancelRegistration() {
      this.showRegistration = false;
    }

}
