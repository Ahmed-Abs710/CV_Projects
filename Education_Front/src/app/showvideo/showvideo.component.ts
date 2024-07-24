import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { ActivatedRoute } from '@angular/router';
import { Addcomment, AllUsers, Comments, Video, Videos } from '../../Models/Users';

@Component({
  selector: 'app-showvideo',
  templateUrl: './showvideo.component.html',
  styleUrl: './showvideo.component.css'
})
export class ShowvideoComponent implements OnInit {

  constructor(private serv: AuthService, private activ: ActivatedRoute, private cd: ChangeDetectorRef) { }
  vidid: number = 0;

  videos: Videos = {
    comment: '',
    courseId: 0,
    courses: null,
    createDate: new Date,
    description: '',
    id: 0,
    title: '',
    videoUrl:''
  };
  users: AllUsers[] = [];
  usernames: string = '';
  addcom: Addcomment = {
    commentText: '',
    userid: localStorage.getItem('UserId')
  };
  comment: Comments[] = [];
  username: string = '';
  ngOnInit(): void {
    this.activ.queryParams.subscribe(res => {
      this.vidid = Number(res['id'])
    });

    
    
    this.serv.GetVideoById(this.vidid).subscribe((result: Videos) => {
      this.vidurl = result.videoUrl;
      this.videos = result;
      // this.cd.detectChanges();
     // alert(this.vidurl);
    });

    this.serv.GetCommentByvideoId(this.vidid).subscribe((res : Comments[]) => {
      this.comment = res;
      this.comment.forEach((user) => {
        this.serv.GetUser(user.userId).subscribe((res: AllUsers) => {
          user.video = res.userName;
         // alert(this.users[1].userName);
        });
      });
    });
    
    
  }
 
  vidurl: string='';
  AddComment() {
    // alert(`${this.vidid} : ${this.addcom.commentText} : ${this.addcom.userid}`);
    this.serv.GetUser(this.addcom.userid).subscribe((res: AllUsers) => {
      this.username = res.userName;
    });
    this.serv.AddComment(this.vidid, this.addcom).subscribe(res => {
    //  alert(this.username);
      res.video = this.username;
      this.comment.push(res);
    });
    
   
  }
  
}
