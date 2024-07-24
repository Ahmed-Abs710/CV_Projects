import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { StudentComponent } from './student/student.component';
import { AdminComponent } from './admin/admin.component';
import { AddStudentComponent } from './add-student/add-student.component';
import { TablecomComponent } from './tablecom/tablecom.component';
import { CreateExamComponent } from './create-exam/create-exam.component';
import { CoursesComponent } from './courses/courses.component';
import { AllvidsComponent } from './allvids/allvids.component';
import { ShowvideoComponent } from './showvideo/showvideo.component';
import { TestComponent } from './test/test.component';
import { ResultComponent } from './result/result.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component : LoginComponent
  },
  {
    path: 'Students',
    component: StudentComponent
  },
  {
    path: 'Teacher',
    component: AdminComponent,
    children: [
      { path: 'addStudent', component: AddStudentComponent },
      { path: 'updateStudents', component: TablecomComponent },
      { path: 'cereateExam', component: CreateExamComponent },
      { path: 'CreateCourses', component: CoursesComponent }
    ]
  },
  {
    path: 'videos',
    component: AllvidsComponent
  },
  {
    path: 'showvideo',
    component: ShowvideoComponent
  },
  {
    path: 'exam',
    component: TestComponent
  },
  {
    path: 'Results',
    component: ResultComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
