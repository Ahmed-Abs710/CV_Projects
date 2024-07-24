import { Component, OnInit } from '@angular/core';
import { AllExams, Answer, Exam, Question } from '../../Models/Users';
import { AuthService } from '../auth.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-create-exam',
  templateUrl: './create-exam.component.html',
  styleUrl: './create-exam.component.css'
})
export class CreateExamComponent implements OnInit{


  constructor(private serv : AuthService , private snak : MatSnackBar) {

  }
  examData: AllExams[] = [];
  questionData: Question[] = [];
    ngOnInit(): void {
      this.serv.GetExams().subscribe((res : AllExams[]) => {
        this.examData = res;
      });
    }
  questonName: string = '';
  examId: number = 0;
  questionid :number =0;
  exam: Exam = {
    Title: '',
    CreateDate:new Date,
    UpdateDate:new Date
  };
  newExam: AllExams = {
    createDate:new Date,
    examResults: '',
    id: 0 ,
    questions: '',
    studentAnswers: '',
    title: '',
    updateDate : new Date
  };
  examtitle: string = '';
  answer: Answer = {
    IsCorrect: false,
    QuestionId: 0,
    Text:''
  };

  AddExam(): void {
    this.exam.Title = this.examtitle;
    // alert(`${this.exam.Title}`);
  
    this.serv.AddExam(this.exam).subscribe(res => {
      this.examData.push(res);
    }, error => {
      alert(error);
    });

    
    this.snak.open(`${this.examtitle} Exam Added`, 'Ok');
  }

  AddQuestion(): void{
   // alert(this.examId);
    this.serv.AddQuestion(this.questonName, this.examId).subscribe(res => {
     this.questionData.push(res);
    }, error => {
      alert(error);
    });
   // this.GetQuestionByExamId();
    this.snak.open(`Question Added`, 'Ok'); 
  }

  GetQuestionByExamId() {
    this.serv.GetQuestionByExamId(this.examId).subscribe((res : Question[]) => {
      this.questionData = res;
    });
  }

  AddAnswer():void {
     alert(`${this.answer.IsCorrect} : ${this.answer.QuestionId} : ${this.answer.Text}`);
    this.serv.AddAnswer(this.answer).subscribe(res => {
      this.snak.open(`Answer Added`, 'Ok'); 
    });
  }

}
