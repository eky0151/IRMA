

import { Component, OnInit } from '@angular/core';
import { Response } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';

import { IRegisterModel } from '../../core//models/register-model';
import { ILoginModel } from '../../core/models/login-model'
import { AccountService } from '../../core/services/account.service'



@Component({
    selector: 'register',
    templateUrl: './register.component.html'
})
export class RegisterComponent {
    public errors: string[] = [];

    constructor(public accountService: AccountService, public router: Router, public route: ActivatedRoute) { }



}
