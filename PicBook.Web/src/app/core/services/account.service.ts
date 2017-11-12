import { Injectable } from '@angular/core';
import { RegisterModel } from '../models/registermodel';
import { Observable } from 'rxjs/Observable';
import { HttpHeaders, HttpClient } from '@angular/common/http';

@Injectable()
export class AccountService {

  constructor(private http: HttpClient) { }

  public Register(data: RegisterModel): Observable<any> {
    var post = this.http.post('http://localhost:57169/api/Account/register', data);
    debugger;
    return post;
  }

}
