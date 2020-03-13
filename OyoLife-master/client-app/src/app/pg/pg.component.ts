import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pg',
  templateUrl: './pg.component.html',
  styleUrls: ['./pg.component.css']
})
export class PgComponent implements OnInit {

  constructor(private router: Router) { }

  ShowDeatils(){
    this.router.navigate(['PgDetail']);
  }
  VisitBooking(){
    this.router.navigate(['VisitBooking']);
  }
  ngOnInit(): void {
  }

}
