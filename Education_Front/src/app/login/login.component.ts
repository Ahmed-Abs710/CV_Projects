import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '../auth.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { Users } from '../../Models/Users';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent{

  //@ViewChild('user') user!: ElementRef;
  //@ViewChild('pass') pass!: ElementRef;

  loginForm: FormGroup;
  constructor(private auth : AuthService ,private fb : FormBuilder ,private rout : Router) {
    this.loginForm = this.fb.group({});
  }

  User: string ='';
  pass: string = '';
  result!: Users;

  show(): void {
    this.auth.Login(this.User, this.pass).subscribe(res => {
      var results;
      this.result = res;

      localStorage.setItem('UserId',this.result.id);
      if (this.result.name === 'Admin') {
          this.rout.navigateByUrl('/Students');
      } else if (this.result.name === 'Teachers' || this.result.name === 'AMD') {
          this.rout.navigateByUrl('/Teacher');
        } else {
          this.error = this.result.name;
      }
     // alert(`${this.result.id}`);
      }
      , error => {
      this.error = error;
      });
     // alert(`${this.result.id}   : ${Object.values(res)}`);
   
    
  }

  //show(): void {
  //  this.auth.Login().subscribe(res => {
  //    this.response = res;
  //  }, error => {
  //    this.response = error;
  //  });
  //  alert(`${this.User} : ${this.pass}`);
  //}
  CheckLogin(): void {
     
  }
  response: Array<any> = [];
  error:string='';

}
