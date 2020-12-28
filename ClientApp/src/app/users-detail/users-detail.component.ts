import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user';

@Component({
  selector: 'usersdetail',
  templateUrl: './users-detail.component.html'
})
export class UsersDetailComponent {
  private baseUrl: string;
  public users: User[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    // Retrieve all the users without pagination
    this.getAllUsers();
  }

  getAllUsers() {
    this.http.get<User[]>(this.baseUrl + 'api/users').subscribe(result => {
      this.users = result;
    }, error => console.error(error));
  }
}