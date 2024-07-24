export interface Users {
  id: string;
  name: string;
}


export interface Roles {
  addStudent: boolean;
  delteStudent: boolean;
  updateStudent: boolean;
  addTeacher: boolean;
  delteTeacher: boolean;
  updateTeacher: boolean;
  addAdmin: boolean;
  sendEmail: boolean;
}


export interface AllRoles {
  addStudent: boolean;
  delteStudent: boolean;
  updateStudent: boolean;
  addTeacher: boolean;
  delteTeacher: boolean;
  updateTeacher: boolean;
  addAdmin: boolean;
  sendEmail: boolean;
  id: string;
  name: string;
  normalizedName: string;
  concurrencyStamp: any;
}

export interface NewUser
{
  Email: string;
  Password: string;
  FullName: string;
  DateOfBirth: Date | null;
  UserName: string;

}

export interface AllUsers {
  fullName: string;
  dateOfBirth: Date | null;
  isActive: boolean;
  expireationDate: Date | null;
  type: any;
  id: string;
  userName: string;
  normalizedUserName: string;
  email: string;
  normalizedEmail: string;
  emailConfirmed: any;
  passwordHash: string;
  securityStamp: any;
  concurrencyStamp: any;
  phoneNumber: any;
  phoneNumberConfirmed: any;
  twoFactorEnabled: any;
  lockoutEnd: any;
  lockoutEnabled: any;
  accessFailedCount: any;

}

export interface UpdateUser {
  FullName: string;
  username: string;
  email: string;
  phone: string;
}
export interface Exam {
  Title: string;
  CreateDate: Date;
  UpdateDate: Date;
}

export interface AllExams {
  id: number;
  title: string;
  createDate: Date;
  updateDate: Date;
  questions: any;
  examResults: any;
  studentAnswers: any;
}

export interface Question {
  id: number;
  text: string;
  examId: number;
  exam: any;
  answers: any;
  studentAnswers: any;
}

export interface Courses {
  id: number;
  title: string;
  description: string;
  instructor: string;
  createDate: Date;
  coursePic: string;
  video: any;
}

export interface Cour {
  Title: string;
  Description: string;
  Instructor: string;
  CoursePic: File | null;
}

  export interface Video{
    courseid: number;
    Title: string;
    Description: string;
    videopath: File | null;
  }


export interface Answer {
  Text: string;
  IsCorrect: boolean;
  QuestionId: number;
}

export interface Videos {
  id: number;
  courseId: number;
  videoUrl: string;
  title: string;
  description: string;
  createDate: Date;
  courses: any;
  comment: any;
}

export interface Comments {
  id: number;
  videoId: number;
  commentText: string;
  userId: string;
  createDate: Date;
  video: any;
}

export interface Addcomment {
  commentText: string;
  userid: string |null;
}

export interface getAnswer {
  id: number;
  text: string;
  isCorrect: boolean;
  questionId: number;
  question: any;
}

export interface Answers {
  answer: getAnswer[];
}

export interface Ans {
  examId: number;
  studentId: string | null;
  questionId: number;
  answerId: number;
  answer: string;
  IsCorrect: boolean;
}

export interface Clacres {
  ExamId: number;
  StudentId: string | null;
}

export interface StuAns {
  id: number;
  examId: number;
  exam: any;
  studentId: string;
  questionId: number;
  question: any;
  answer: string;
  isCorrect: boolean;
}

export interface ExamResult {
  id: number;
  examId: number;
  exam: any;
  studentId: string;
  score: number;
}
