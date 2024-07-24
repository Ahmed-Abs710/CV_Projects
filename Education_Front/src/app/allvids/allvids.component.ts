import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { Videos } from '../../Models/Users';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-allvids',
  templateUrl: './allvids.component.html',
  styleUrl: './allvids.component.css'
})
export class AllvidsComponent implements OnInit{

  videos: Videos[] = [];
  constructor(private serv: AuthService, private activ: ActivatedRoute, private rout: Router) { }
    ngOnInit(): void {
      this.activ.queryParams.subscribe(res => {
        this.serv.GetVideoByCourseId(Number(res['id'])).subscribe(result => {
          this.videos = result;
        });
      });
  }

  GO(vidid: number): void {
    this.rout.navigate(['showvideo'], { queryParams: { id: vidid } });
  }

}
