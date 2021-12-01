import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { forkJoin, Observable, of } from 'rxjs';
import { HttpEndpoints } from '../models/App/http-endpoints';
import { HttpMethod } from '../models/App/http-methods';
import { Register } from '../models/App/Register';
import { User } from '../models/App/User';
import { HttpService } from './http.service';
import { map, mergeMap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  user: User | undefined;

  constructor(private httpService: HttpService) { }

  register(register: Register) : Observable<any> {
    return this.httpService.makeHttpCall(HttpEndpoints.Register, HttpMethod.POST, register);
  }

  login(email: string, password: string) : Observable<User> {
    return this.httpService.makeHttpCall(HttpEndpoints.Login, HttpMethod.POST, { email, password }).pipe(
      mergeMap(
        (token) => {
            this.httpService.setToken(token);
            return this.httpService.makeHttpCall(HttpEndpoints.GetUser, HttpMethod.GET).pipe(map(
              (user) => {
                  this.user = user;
                  return user;
              }
          ))
        }
    ))
  }
}
