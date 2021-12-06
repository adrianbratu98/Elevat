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

  private baseUri ="https://localhost:5001/api";

  private token: string | undefined;

  constructor(private httpClient: HttpClient) { }

  public makeHttpCall(endPoint: HttpEndpoints, method: HttpMethod, param?:any) : Observable<any> {
    let obs: Observable<any>;
    switch(method) {
      case HttpMethod.GET: {
        obs = this.httpClient.get(`${this.baseUri}/${endPoint.toString()}`, { headers: this.getHeaders(), responseType: 'text' });
        break;
      }
      case HttpMethod.POST: {
        obs = this.httpClient.post(`${this.baseUri}/${endPoint.toString()}`, param, { headers: this.getHeaders(), responseType: 'text' });
        break;
      } 
      case HttpMethod.PUT: {
        obs = this.httpClient.put(`${this.baseUri}/${endPoint.toString()}`, param, { headers: this.getHeaders(), responseType: 'text' });
        break;
      } 
      case HttpMethod.DELETE: {
        obs = this.httpClient.delete(`${this.baseUri}/${endPoint.toString()}/${param}`, { headers: this.getHeaders(), responseType: 'text' });
        break;
      }
      default: throw new Error("Invalid http method");
    }
    return obs.pipe(map(
      (response) => {
        if(response[0] == "{" && response[response.length - 1] == "}")
          return JSON.parse(response);
        return response;
      }
    ))
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
