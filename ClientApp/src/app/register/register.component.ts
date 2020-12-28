import { Component, Input, Output } from '@angular/core';
import { EventEmitter } from 'events';
import { User } from '../models/user';
import { SecurityService } from '../services/security.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent {
  userModel: User;

  constructor(private securityService: SecurityService) {

  }

  register() {
    this.securityService.register(this.userModel).subscribe(response => {
      this.userModel = response;
      this.securityService.setUserSession(this.userModel);
    });
  }

}
