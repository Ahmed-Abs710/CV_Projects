import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { Roles } from '../../Models/Users';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent implements OnInit{

  constructor(private serv: AuthService, private rout: Router) { }

  roles!: Roles;
  id: string | null = localStorage.getItem('UserId');
  error: string = '';
    ngOnInit(): void {
      this.serv.GetPermissions(this.id).subscribe(res => {
        if (res && res.length > 0) {
          this.roles = res[0];
        }
        
       // alert(`${res[0]}`);
      });
    

    }

}
