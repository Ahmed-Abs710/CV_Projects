import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { AllExams, Courses } from '../../Models/Users';
import { Router } from '@angular/router';


@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrl: './student.component.css'
})
export class StudentComponent implements OnInit{
  constructor(private serv: AuthService,private rout : Router) { }

  courses: Courses[] = [];
  exams: AllExams[] = [];
    ngOnInit(): void {
      this.serv.GetCourses().subscribe((res : Courses[]) => {
        this.courses = res;
      });
      this.serv.GetExams().subscribe(res => {
        this.exams = res;
      });
     // this.courses[0].coursePic
  }

  GO(vidid : number): void {
    this.rout.navigate(['videos'], { queryParams: {id: vidid}});
  }

  GOExam(exid: number): void {
    this.rout.navigate(['exam'], { queryParams: { id: exid } });
  }

}
