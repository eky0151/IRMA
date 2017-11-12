
import { RegisterModel } from  '../core/models/registermodel';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../core/services/account.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class RegisterComponent implements OnInit {

  registerModel : RegisterModel;

  constructor(private accountService: AccountService, public router: Router, public route: ActivatedRoute) { }

  ngOnInit() {
    this.registerModel = new RegisterModel();
    this.registerModel.firstname = "";
    this.registerModel.lastname = "";
    this.registerModel.email = "";
    this.registerModel.username = "";
    this.registerModel.password = "";
    this.registerModel.password2 = "";
  }

  public RegisterNewuser(): void {
    debugger;
    if (this.registerModel.password2 == this.registerModel.password) {
      this.accountService.Register(this.registerModel).subscribe((res: Response) => {
        this.router.navigate(['../login'], { relativeTo: this.route});
      });
    }

  }

}
