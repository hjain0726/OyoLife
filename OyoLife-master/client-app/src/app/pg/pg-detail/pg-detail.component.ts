import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PgService } from '../pg.service';

@Component({
  selector: 'app-pg-detail',
  templateUrl: './pg-detail.component.html',
  styleUrls: ['./pg-detail.component.css']
})
export class PgDetailComponent implements OnInit {

  pgDetail:any;

  constructor(private router: Router,private pgService:PgService) { 
  }

  close(){
    this.router.navigate(['']);
  }

  ngOnInit(): void {
    this.pgDetail=this.pgService.pg;
    console.log(this.pgDetail);
  }

}
