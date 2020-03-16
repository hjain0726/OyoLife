import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PgService } from '../pg.service';
import { BookingService } from 'src/app/visit-booking/booking.service';

@Component({
  selector: 'app-pg-list',
  templateUrl: './pg-list.component.html',
  styleUrls: ['./pg-list.component.css']
})
export class PgListComponent implements OnInit {

  gender:string='';
  occupancy:string='';
  location:string='';
  monthlyRent: { start: number, end: number }=null;
  loader=true;
  AllPgs:any

  constructor(private router: Router, private pgService:PgService,private bookingService:BookingService) { }

  ShowDeatils(pg){
    this.pgService.pg=pg;
    this.router.navigate(['PgDetail']);
  }
  VisitBooking(pg){
    this.bookingService.pg=pg;
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

    this.pgService.applyGenderFilter.subscribe((gender)=>{
      this.gender=gender;
    });

    this.pgService.applyOccupancyFilter.subscribe((occupancy)=>{
      this.occupancy=occupancy;
    });
    
    this.pgService.applyMonthlyRentFilter.subscribe((monthlyRent)=>{
      this.monthlyRent=monthlyRent;
    });

    this.pgService.applyLocationFilter.subscribe((location)=>{
      this.location=location;
    })
  }

}
