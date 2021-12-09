import { HttpClient, HttpHeaders } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { forkJoin, Observable, of } from 'rxjs';
import { HttpEndpoints } from '../models/App/http-endpoints';
import { HttpMethod } from '../models/App/http-methods';
import { Register } from '../models/App/Register';
import { User } from '../models/App/User';
import { HttpService } from './http.service';
import { delay, map, mergeMap } from 'rxjs/operators';
import { AccountListDto } from '../models/Dto/account-list-dto';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  user: User | undefined;

  userLoggedIn: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor(private httpService: HttpService) { }

  register(register: Register) : Observable<any> {
    return this.httpService.makeHttpCall(HttpEndpoints.Register, HttpMethod.POST, register);
  }

  tryLogin() : Observable<any> {
    let token = localStorage.getItem('token');
    if(token) {
      this.httpService.setToken(token);
      return this.getUser();
    }
    return of();
  }

  login(email: string, password: string) : Observable<User> {
    return this.httpService.makeHttpCall(HttpEndpoints.Login, HttpMethod.POST, { email, password }).pipe(
      mergeMap(
        (token) => {
            this.httpService.setToken(token.token);
            localStorage.setItem('token', token.token);
            return this.getUser();
        },
    ))
  }

  private getUser() : Observable<User> {
    return this.httpService.makeHttpCall(HttpEndpoints.GetUser, HttpMethod.GET).pipe(map(
      (user: User) => {
          this.user = user;
          this.userLoggedIn.emit(true);
          return user;
      }
    ));
  }

  logout() {
    this.user = undefined;
    this.userLoggedIn.emit(false);
    localStorage.removeItem('token');
  }
}
