import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { Addcomment, AllExams, AllRoles, AllUsers, Ans, Answer, Clacres, Comments, Cour, Courses, Exam, ExamResult, NewUser, Question, Roles, StuAns, UpdateUser, Videos, getAnswer } from '../Models/Users';

@Injectable({
  providedIn: 'root'
})
//interface LoginResbonse {
//  token: string;
//}
export class AuthService {

  

  private apiurl = `https://localhost:7143/api/Login/login`;
  private getpermissionurl = `https://localhost:7143/api/Role/GetUserRolesAsync?userid=5239290e-a222-4e38-bff8-c0a876cea4b0`;

  private serv = 'https://localhost:7143/api/Role/GetUserRolesAsync?userid=';

  private assign = 'https://localhost:7143/api/User/RegisterUser?roleid=';

  private users = 'https://localhost:7143/api/User/api/users/GetAllUsers';

  private delete = 'https://localhost:7143/api/User/api/users/DeleteUser?userid=';

  private updateUser = 'https://localhost:7143/api/User/api/users/UpdateUser?UserId=';

  private addexam = 'https://localhost:7199/api/Exam/CreateExam';

  private AllExams = 'https://localhost:7199/api/Exam/GetAllExams';

  private addQuestion = 'https://localhost:7199/api/Question/CreateQuestion';

  private getquestionbuExam = 'https://localhost:7199/api/Question/GetAllQuestionsByExamId?examid=';

  private createCoures = 'https://localhost:7273/api/Course/CreateCourse';

  private AllCouses = 'https://localhost:7273/api/Course/GetAllCourses';

  private addvideo = 'https://localhost:7273/api/Video/AddVideoToCourse';

  private addanswer = 'https://localhost:7199/api/Answer/CreateAnswer';

  private courvid = 'https://localhost:7273/api/Video/GetAllVideosForCourse?courseid=';

  private vidid = 'https://localhost:7273/api/Video/GetVideoById?videoid=';

  private comment = 'https://localhost:7273/api/Comment/GetAllCommentsForVideo/';

  private addcom = 'https://localhost:7273/api/Comment/AddCommentToVideo?videoid=';
  private getuser = 'https://localhost:7143/api/User/api/users/GetUserById?userid2=';

  private getans = 'https://localhost:7199/api/Answer/GetAllAnswersByQuestionId?questionid=';

  private addans = 'https://localhost:7199/api/Exam/SubmitAnswer';

  private result = 'https://localhost:7199/api/Exam/CreateExamResultAsync';

  constructor(private http : HttpClient) {
  }
  Login(username: string, password: string): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const body = JSON.stringify({ username, password });
    return this.http.post<any>(`${this.apiurl}`, body, {headers}).pipe(catchError(this.HandelError));
  }

  AddUser(roleId: string, data: NewUser): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const body = JSON.stringify({ data });
    return this.http.post<any>(`${this.assign}${roleId}`, data,
      { headers }).pipe(catchError(this.HandelError));
  }

  AddExam( data: Exam): Observable<AllExams> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<AllExams>(`${this.addexam}`, data,
      { headers }).pipe(catchError(this.HandelError));
  }

  AddQuestion(Text: string, ExamId: number): Observable<Question> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const body = JSON.stringify({ Text, ExamId });
    return this.http.post<Question>(`${this.addQuestion}`, body,
      { headers }).pipe(catchError(this.HandelError));
  }

  AddCourse(data: FormData): Observable<Courses> {
    return this.http.post<Courses>(`${this.createCoures}`, data).pipe(catchError(this.HandelError));
  }

  AddAnswer(data: Answer): Observable<StuAns> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<StuAns>(`${this.addanswer}`, data, { headers }).pipe(catchError(this.HandelError));
  }

  CLaculateResult(data: Clacres): Observable<ExamResult> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<ExamResult>(`${this.result}`, data, { headers }).pipe(catchError(this.HandelError));
  }

  Answer(data: Ans): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<any>(`${this.addans}`, data, { headers }).pipe(catchError(this.HandelError));
  }

  AddComment(vidid: number, data: Addcomment): Observable<Comments> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<Comments>(`${this.addcom}${vidid}`, data, { headers }).pipe(catchError(this.HandelError));
  }

  AddVideo(data: FormData): Observable<any> {
    return this.http.post<any>(`${this.addvideo}`, data).pipe(catchError(this.HandelError));
  }

  GetPermissions(Id: string | null): Observable<Roles[]> {
   // const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
   // const body = JSON.stringify({ Id });
    return this.http.get<Roles[]>('https://localhost:7143/api/Role/GetUserRolesAsync?userid=' + Id).pipe(catchError(this.HandelError));
  }

  GetQuestionByExamId(Id: number | null): Observable<Question[]> {
    return this.http.get<Question[]>(this.getquestionbuExam + Id).pipe(catchError(this.HandelError));
  }

  GetVideoByCourseId(Id: number): Observable<Videos[]> {
    return this.http.get<Videos[]>(this.courvid + Id).pipe(catchError(this.HandelError));
  }

  GetVideoById(Id: number): Observable<Videos> {
    return this.http.get<Videos>(this.vidid + Id).pipe(catchError(this.HandelError));
  }

  GetAnswerById(Id: number): Observable<getAnswer[]> {
    return this.http.get<getAnswer[]>(this.getans + Id).pipe(catchError(this.HandelError));
  }

  GetCommentByvideoId(Id: number): Observable<Comments[]> {
    return this.http.get<Comments[]>(this.comment + Id).pipe(catchError(this.HandelError));
  }

  GetExams(): Observable<AllExams[]> {
    return this.http.get<AllExams[]>(this.AllExams).pipe(catchError(this.HandelError));
  }

  GetCourses(): Observable<Courses[]> {
    return this.http.get<Courses[]>(this.AllCouses).pipe(catchError(this.HandelError));
  }

  DeleteUser(Id: string): Observable<any> {
    return this.http.delete<any>(this.delete + Id).pipe(catchError(this.HandelError));
  }

  UpdateeUser(Id: string, data: UpdateUser): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.put<any>(this.updateUser + Id, data, { headers}).pipe(catchError(this.HandelError));
  }

  GetUsers(): Observable<AllUsers[]> {
    return this.http.get<AllUsers[]>(this.users).pipe(catchError(this.HandelError));
  }

  GetUser(id : string | null): Observable<AllUsers> {
    return this.http.get<AllUsers>(this.getuser+id).pipe(catchError(this.HandelError));
  }

  GetAllRoles(): Observable<AllRoles[]> {
    // const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    // const body = JSON.stringify({ Id });
    return this.http.get<AllRoles[]>('https://localhost:7143/api/Role/GetAllRoles').pipe(catchError(this.HandelError));
  }






  private HandelError(error : HttpErrorResponse) {
    let errorMessage = 'Unknown Error!';
    if (error.error instanceof ErrorEvent) {
      errorMessage = `Client-Side Error !!  ${error.error.message}`;
    } else {
      errorMessage = `Server-Side Error !! ${error.status} : ${error.error.message}  ${error.type}  ${error.name}` ;
      if (error.error) {
        errorMessage = `Server-Side Error !!  ${error.status} : ${error.error}  ${error.statusText}`;
      }
    }
    return throwError(errorMessage);
  }

}
