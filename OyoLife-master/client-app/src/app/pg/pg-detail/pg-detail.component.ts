import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PgService } from '../pg.service';
import { BookingService } from 'src/app/visit-booking/booking.service';

@Component({
  selector: 'app-pg-detail',
  templateUrl: './pg-detail.component.html',
  styleUrls: ['./pg-detail.component.css']
})
export class PgDetailComponent implements OnInit {

  pgDetail:any;

  constructor(private router: Router,private pgService:PgService,private bookingService:BookingService) { 
  }

  close(){
    this.router.navigate(['']);
  }
  
  VisitBooking(pg){
    this.bookingService.pg=pg;
    this.router.navigate(['VisitBooking']);
  }
  ngOnInit(): void {
    this.pgDetail=this.pgService.pg;
    console.log(this.pgDetail);

    this.pgService.hideSearchBar();
  }

}
