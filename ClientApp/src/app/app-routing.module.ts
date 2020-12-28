
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';
import { UsersDetailComponent } from './users-detail/users-detail.component';
import { MessagesComponent } from './messages/messages.component';
import { MatchesComponent } from './matches/matches.component';
import { RouteGuard } from './guard/route.guard';

const routes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'messages', component: MessagesComponent, canActivate: [RouteGuard] },
    { path: 'matches', component: MatchesComponent, canActivate: [RouteGuard] },
    { path: 'users', component: UsersComponent, canActivate: [RouteGuard] },
    { path: 'usersdetail/:id', component: UsersDetailComponent, canActivate: [RouteGuard] },
    { path: '**', component: HomeComponent, pathMatch: 'full' }
  ];
  
  @NgModule({
    imports: [
      RouterModule.forRoot(routes)
    ],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }
  