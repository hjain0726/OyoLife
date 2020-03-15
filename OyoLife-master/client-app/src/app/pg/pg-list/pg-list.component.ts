import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PgService } from '../pg.service';

@Component({
  selector: 'app-pg-list',
  templateUrl: './pg-list.component.html',
  styleUrls: ['./pg-list.component.css']
})
export class PgListComponent implements OnInit {

  loader=true;
  AllPgs:any

  constructor(private router: Router, private pgService:PgService) { }

  ShowDeatils(pg){
    this.pgService.pg=pg;
    this.router.navigate(['PgDetail']);
  }
  VisitBooking(){
    this.router.navigate(['VisitBooking']);
  }

  ngOnInit(): void {
    this.loader=true;
    this.pgService.getPGs().subscribe((data)=>{
      this.loader=false;
      this.AllPgs=data;
      this.pgService.AllPGs=data;
      console.log(data);
    });
  }

}
