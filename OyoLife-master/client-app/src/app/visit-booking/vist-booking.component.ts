import { Component, OnInit, ViewChild } from '@angular/core';
import { BookingService } from './booking.service';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-vist-booking',
  templateUrl: './vist-booking.component.html',
  styleUrls: ['./vist-booking.component.css']
})
export class VistBookingComponent implements OnInit {

 @ViewChild('date',{static:true}) bookingDate;
  @ViewChild('time',{static:true}) bookingTime;

  constructor(private bookingService:BookingService) { }

  bookVisit(){
    console.log(this.bookingDate.nativeElement.value);
    console.log(this.bookingTime.nativeElement.value);
  }
  
  ngOnInit(): void {
  }

}
