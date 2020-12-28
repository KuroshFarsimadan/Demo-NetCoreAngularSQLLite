import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user';

@Component({
  selector: 'users',
  templateUrl: './users.component.html'
})
export class UsersComponent {
  private baseUrl: string;
  public users: User[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    // Retrieve all the users without pagination
    this.getAllUsers();
    //  this.getAllUsersV2();
  }

  getAllUsers() {
    this.http.get<User[]>(this.baseUrl + 'api/users').subscribe(result => {
      this.users = result;
    }, error => console.error(error));
  }

  getAllUsersV2() {
    this.http.get<User[]>(this.baseUrl + 'api/v2/usersv2').subscribe(result => {
      this.users = result;
    }, error => console.error(error));
  }
}

