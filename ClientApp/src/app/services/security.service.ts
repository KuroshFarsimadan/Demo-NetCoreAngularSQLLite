import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { User } from '../models/user';

import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';



@Injectable({
  providedIn: 'root'
})
export class SecurityService implements HttpInterceptor {
  private baseUrl: string;
  private userModel: User;

  constructor(private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl + "api/";
    let testerSession = localStorage.getItem('userModel');
    if (testerSession) {
      this.userModel = JSON.parse(testerSession);
    }
  }

  // Basic intercepter for adding the authorization token on every HTTP request to backend
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (localStorage.getItem('access-token') !== null) {
      const token = localStorage.getItem('access-token');
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });
      // Build a basic intercepter for HTTP error messages here for testing. You should however, build a service for each interceptor.
      // TESTING CODE and use the notifications component for the logic and template
      return next.handle(request).pipe(
        catchError(error => {
          if (error) {
            // For testing purposes, use the console.log 
            // alert(error); 
            console.log(error);
          }
          // error.status can be used to return different error messages or logic based on the error type or statuscode
          return throwError(error);
        }
        )
      );
    } else {
      return next.handle(request).pipe(
        catchError(error => {
          if (error) {
            // For testing purposes, use the console.log 
            // alert(error); 
            console.log(error);
          }
          return throwError(error);
        }
        )
      );
    }
  }

  getUserSession(): User {
    let testerSession = localStorage.getItem('userModel');
    if (testerSession) {
      this.userModel = JSON.parse(testerSession);
      return this.userModel;
    }
    // return this.userModel: User;
    return this.userModel;
  }
  /* async */
  login(userModel: any) {
    // if (!this.userModel) {
    // let response = await this.getUser(userModel);
    // this.userModel = response;
    return this.http.post<User>(this.baseUrl + 'login/signin', userModel);
    // this.http.post<User>(this.baseUrl + 'login/signin', userModel).subscribe(response => {
    //   this.userModel = response;
    //   localStorage.setItem('userModel', JSON.stringify(this.userModel));
    // });
    // }
    // return this.userModel;
  }

  setUserSession(userModel: User) {
    this.userModel = userModel;
    localStorage.setItem('userModel', JSON.stringify(this.userModel));
    localStorage.setItem('access-token', this.userModel.token);
  }

  register(userModel: User) {
    return this.http.post<User>(this.baseUrl + 'registration/register', userModel);
  }

  // getUser(userModel: any) {
  //   // OR
  //   // return this.http.post(this.baseUrl + 'login/signin', userModel).pipe(
  //   //   map(
  //   //     (response: User) => {
  //   //         this.userModel = response;
  //   //         if (this.userModel) {
  //   //           localStorage.setItem('userModel', JSON.stringify(this.userModel));
  //   //         }
  //   //       }
  //   //     )
  //   //   );
  //   // return this.http.post(this.baseUrl + 'login/signin', userModel);
  //   // OR 
  //   // return this.http.post(this.baseUrl + 'login/signin', userModel).subscribe(response => {
  //   //   this.userModel = response;
  //   // });
  // }
}
