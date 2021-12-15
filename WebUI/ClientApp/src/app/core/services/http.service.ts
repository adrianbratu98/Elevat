import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpEndpoints } from '../models/App/http-endpoints';
import { HttpMethod } from '../models/App/http-methods';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  private baseUri ="https://localhost:44372/api";

  private token: string | undefined;

  constructor(private httpClient: HttpClient) { }

  public makeHttpCall(endPoint: HttpEndpoints, method: HttpMethod, param?:any) : Observable<any> {
    switch(method) {
      case HttpMethod.GET: return this.httpClient.get(`${this.baseUri}/${endPoint.toString()}`, { headers: this.getHeaders()});
      case HttpMethod.POST: return this.httpClient.post(`${this.baseUri}/${endPoint.toString()}`, param, { headers: this.getHeaders()});
      case HttpMethod.PUT: return this.httpClient.put(`${this.baseUri}/${endPoint.toString()}`, param, { headers: this.getHeaders()});
      case HttpMethod.DELETE: return this.httpClient.delete(`${this.baseUri}/${endPoint.toString()}/${param}`, { headers: this.getHeaders()});
      default: throw new Error("Invalid http method");
    }
  }

  setToken(token: string) {
    this.token = token;
  }

  private getHeaders() : HttpHeaders {
    let headers = new HttpHeaders({
      'Authorization': `Bearer ${this.token}`,
    })
    return headers;
  }
}
