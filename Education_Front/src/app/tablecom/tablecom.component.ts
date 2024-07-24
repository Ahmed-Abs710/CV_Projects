import { Component, OnInit, ViewChild } from '@angular/core';
import { AllUsers, UpdateUser } from '../../Models/Users';
import { AuthService } from '../auth.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { filter, timeout } from 'rxjs';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}
const ELEMENT_DATA: PeriodicElement[] = [
  { position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H' },
  { position: 2, name: 'Helium', weight: 4.0026, symbol: 'He' },
  { position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li' },
  { position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be' },
  { position: 5, name: 'Boron', weight: 10.811, symbol: 'B' },
  { position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C' },
  { position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N' },
  { position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O' },
  { position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F' },
  { position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne' },
];

@Component({
  selector: 'app-tablecom',
  templateUrl: './tablecom.component.html',
  styleUrl: './tablecom.component.css'
})



export class TablecomComponent implements OnInit{

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  Refresh: boolean = true;
  constructor(private serv : AuthService) { }
  data!: AllUsers[];
  d: any;
  updateuser: UpdateUser = {
    email: '',
    FullName: '',
    phone: '',
    username:''
  };
  GetData() {
   this.serv.GetUsers().subscribe((res: AllUsers[]) => {
      this.data = res
      this.dataSource.data = this.data;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }
  dataSource= new MatTableDataSource<AllUsers>(this.data);
  ngOnInit(): void {
    this.serv.GetUsers().subscribe((res:AllUsers[]) => {
      this.data = res
      this.dataSource.data = this.data;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
    //setTimeout(() => { this.dataSource = ELEMENT_DATA; }, 3);
    // alert(`${this.data[0].userName} : ${this.data[0].email}`);
    //this.dataSource.paginator = this.paginator;
    //this.dataSource.sort = this.sort
    
  }
  Delete(id: string): void {
    this.serv.DeleteUser(id).subscribe((res : any)=> {
     
    });
    this.serv.GetUsers().subscribe((res: AllUsers[]) => {
      this.dataSource.data = res;
      this.dataSource.data = this.dataSource.data.filter(em=>em.id !== id);
    });
  }

  Update(data: AllUsers): void {
    
    this.updateuser.email = data.email;
    this.updateuser.FullName = data.fullName;
    this.updateuser.phone = data.phoneNumber;
    this.updateuser.username = data.userName;
   // alert(this.updateuser.email);
    this.serv.UpdateeUser(data.id, this.updateuser).subscribe(res => {
     alert(Object.values(res));
    });
    
  }
//  dataSource = new MatTableDataSource<AllUsers>(this.data);

  displayedColumns: string[] = ['fullName', 'userName', 'email', 'phoneNumber','actions'];
  
 
}
