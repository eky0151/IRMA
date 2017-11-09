import { IRegisterModel } from '../models/register-model';
import { ILoginModel } from '../models/login-model'


import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http } from '@angular/http';

@Injectable()
export class AccountService {

    constructor(private httpClient: Http) { }

    public register(data: IRegisterModel): Observable<any> {
        return this.httpClient.post('api/account/register', data);
    }
}