import { Component, OnDestroy, OnInit } from '@angular/core';
import { interval } from 'rxjs';
import { take, map } from 'rxjs/operators';
import { Ans, Answers, Clacres, ExamResult, Question, StuAns, getAnswer } from '../../Models/Users';
import { AuthService } from '../auth.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrl: './test.component.css'
})
export class TestComponent implements OnInit, OnDestroy{
  constructor(private serv: AuthService, private activ: ActivatedRoute ,private rout : Router) { }
  ngOnDestroy(): void {
    if (this.interval) {
      clearInterval(this.interval);
    }
  }
  showResult: boolean = false;
  Result: number = 0;
 isCorrect : boolean=false;
  questions: Question[] = [];
  answers: Array<getAnswer[]> = [];
  curmins: number = 0;
  examid: number = 0;
  timeleft: string = '';
  stuId: string | null = localStorage.getItem('id');
  answer: Ans = {
    answer: '',
    answerId: 0,
    examId: this.examid,
    questionId: 0,
    studentId: localStorage.getItem('UserId'),
    IsCorrect: this.isCorrect
  };
  private interval: any;
  
  ngOnInit(): void {
    this.activ.queryParams.subscribe(res => {
      this.examid = Number(res['id'])
    });

   

    this.serv.GetQuestionByExamId(this.examid).subscribe(res => {
      this.questions = res;
      this.questions.forEach(ans => {
        this.serv.GetAnswerById(ans.id).subscribe(res2 => {
         // this.answers.push(res2);
          ans.answers = res2;
         
        });
      });
    })
  
  

   const mins = 5;
    let seconds = mins * 60;
    this.UpdateTimeLeft(seconds);
    this.curmins = mins;
    this.interval = setInterval(() => {
      seconds--;
      this.UpdateTimeLeft(seconds);
      if (seconds <= 0) {
        clearInterval(this.interval);
        this.CreateResult();
      }
    },1000);
    
  }

  private UpdateTimeLeft(time : number) {
    const min =Math.floor(time / 60);
    const sec = (time % 60);
    this.timeleft = `${this.FormatTime(min)} : ${this.FormatTime(sec)}`;
    this.curmins = min;
  }

  private FormatTime(value : number):string {
    return value < 10 ? `0${value}` : value.toString(); 
  }

  AddAnswer(qustionid: number, ans : string,ei : number,ev : boolean) {
    this.answer.questionId = qustionid;
    this.answer.answerId = ei;
    this.answer.answer = ans;
    this.answer.examId = this.examid;
    this.answer.IsCorrect = ev;
    this.serv.Answer(this.answer).subscribe((res: StuAns) => {
      //alert(`${res.questionId} : ${res.answer} : ${res.examId} : ${res.examId} :
      //${res.studentId} : ${res.isCorrect}`)

    });
  }
  calc: Clacres={
    ExamId: this.examid,
    StudentId: localStorage.getItem('UserId')
  }
 
  CreateResult(): void {
    this.calc.ExamId = this.examid;
    // this.calc = localStorage.getItem('id')
    //  alert(`${this.calc.ExamId} : ${this.calc.StudentId}`);
    this.serv.CLaculateResult(this.calc).subscribe((res: ExamResult) => {
      // alert(`${res.score} : ${res.id} : ${res.studentId}`);
      localStorage.setItem('Result', res.score.toString());
      this.Result = res.score;
      this.rout.navigateByUrl('Results');
    });
  }
}
