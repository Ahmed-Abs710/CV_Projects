import { ChangeDetectionStrategy, Component, OnInit, signal } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { merge } from 'rxjs';
import { AuthService } from '../auth.service';
import { AllRoles, NewUser, Roles } from '../../Models/Users';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrl: './add-student.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AddStudentComponent implements OnInit{
  readonly email = new FormControl('', [Validators.required, Validators.email]);

  errorMessage = signal('');
  Allrole!: AllRoles[];
  username: string = '';
  password: string = '';
  mail: string = '';
  date: Date | null = null;
  fullname: string = '';
  roleid: string = '';
  constructor(private serv :AuthService) {
    merge(this.email.statusChanges, this.email.valueChanges)
      .pipe()
      .subscribe(() => this.updateErrorMessage());
  }
    ngOnInit(): void {
      this.serv.GetAllRoles().subscribe(res => {
        this.Allrole = res;
      });
    //  this.Allrole[0].id
    }
  Show() {
    alert(this.username + '  :  ' + this.date?.toString() + ' : ' + this.roleid);
  }


  hide = signal(true);
  clickEvent(event: MouseEvent) {
    this.hide.set(!this.hide());
    event.stopPropagation();
  }


  User: NewUser = {
    Email: '',
    Password: '',
    FullName:'',
    DateOfBirth: null,
    UserName :''
  };

 

  AddNewUser()
  {
    this.User.UserName = this.username;
    this.User.DateOfBirth = this.date;
    this.User.Email = this.mail;
    this.User.FullName = this.fullname;
    this.User.Password = this.password;

    this.serv.AddUser(this.roleid, this.User).subscribe(res => {
      alert(res);
    },error=>{
      alert(error);
    });

   // alert(this.User.Password);
   //   + ` : ${this.User.fullName} : ${this.User.password} : ${this.User.email}`);
  }
  updateErrorMessage() {
    if (this.email.hasError('required')) {
      this.errorMessage.set('You must enter a value');
    } else if (this.email.hasError('email')) {
      this.errorMessage.set('Not a valid email');
    } else {
      this.errorMessage.set('');
    }
  }
}


