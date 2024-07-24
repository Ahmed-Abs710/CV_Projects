import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { Cour, Courses, Video } from '../../Models/Users';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrl: './courses.component.css'
})
export class CoursesComponent implements OnInit{

  constructor(private serv: AuthService, private snak: MatSnackBar) {

  }

  
  ngOnInit(): void {
 
      this.serv.GetCourses().subscribe((res: Courses[]) => {
        this.CourseData = res;
      });
    }

  Course: Courses = {
    createDate: new Date,
    description: '',
    id: 0,
    instructor: '',
    title: '',
    coursePic :'',
    video:''
  };

  cour: Cour = {
    Title: '',
    CoursePic: null,
    Description: '',
    Instructor:''
  }
  file!: File;

  GetFile(event : Event) :void {
    const file = event.target as HTMLInputElement;
    if (file.files) {
      this.cour.CoursePic = file.files[0];
    }
  }

  GetVideoFile(event: Event): void {
    const file = event.target as HTMLInputElement;
    if (file.files) {
      this.video.videopath = file.files[0];
    }
  }

  CourseData: Courses[] = [];
  courseId: number = 0;

  video: Video = {
    courseid: 0,
    Description: '',
    Title: '',
    videopath:null
  }

  AddCourse(): void {
    
    if (this.cour.CoursePic) {
      const form = new FormData();
      form.append('CoursePic', this.cour.CoursePic, this.cour.CoursePic.name);
      form.append('Title', this.cour.Title);
      form.append('Description', this.cour.Description);
      form.append('Instructor', this.cour.Instructor);
      this.serv.AddCourse(form).subscribe((res: Courses) => {
        this.CourseData.push(res);
      });
    }
    this.snak.open(`Course Added`, 'Ok'); 
  }

  AddVideo(): void {

    if (this.video.videopath) {
      const form = new FormData();
      //  alert(`${this.video.courseid} : ${this.video.Description} : ${this.video.Title} : ${this.video.videopath.name}`);
      form.append('courseid', this.video.courseid.toString());    
      form.append('Title', this.video.Title);
      form.append('Description', this.video.Description);
      form.append('videopath', this.video.videopath, this.video.videopath.name);
      this.serv.AddVideo(form).subscribe(res=> {
        //this.CourseData.push(res);
      });
    }
    this.snak.open(`Video Added`, 'Ok');
  }

}
