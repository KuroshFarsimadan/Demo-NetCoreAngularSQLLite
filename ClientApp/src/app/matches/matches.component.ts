import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'matches',
  templateUrl: './matches.component.html'
})
export class MatchesComponent {
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

interface User {
  id: number;
  userName: string;
}
