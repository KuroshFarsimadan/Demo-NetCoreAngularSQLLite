import { Component } from '@angular/core';
import { User } from '../models/user';
import { SecurityService } from '../services/security.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  userModel: User;
  sessionActive: boolean;

  constructor(private securityService: SecurityService) { }

  ngOnInit() {
    let tester = this.securityService.getUserSession();
    if (tester) {
      this.sessionActive = true;
      this.userModel = tester;
    } else {
      console.log(this.userModel);
      this.userModel = {
        username: "",
        password: "",
        token: "",
        errors: ""
      };
    }
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  login() {
    this.securityService.login(this.userModel).subscribe(response => {
      this.userModel = response;
      console.log(this.userModel);
      this.securityService.setUserSession(this.userModel);
      this.sessionActive = true;
    });

  }

  logout() {
    // The login and logout example is 100x simpler than what we would usually see in the registration, login and logout processes in the
    // real world applications. This is only to showcase a skeleton for the backend.
    sessionStorage.clear();
    localStorage.clear();
    this.sessionActive = false;
    this.userModel.errors = "";
    this.userModel.username = "";
    this.userModel.token = "";
    this.userModel.password = "";
  }
}
