import { Component, OnInit, ViewChild } from '@angular/core';
import { BookingService } from './booking.service';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { PgService } from '../pg/pg.service';

declare var swal: any;

@Component({
  selector: 'app-vist-booking',
  templateUrl: './vist-booking.component.html',
  styleUrls: ['./vist-booking.component.css']
})
export class VistBookingComponent implements OnInit {

  msg: any;
  @ViewChild('date', { static: true }) bookingDate;
  @ViewChild('time', { static: true }) bookingTime;

  constructor(private bookingService: BookingService, private router: Router,private pgService:PgService) { }
  loader = false;

  bookVisit() {
    this.loader = true;
    let date = this.bookingDate.nativeElement.value + "T00:00:00";
    let time = this.bookingTime.nativeElement.value;
    if (date == "" || time == "") {
      this.msg = "Date or Time required"
      this.loader=false;
    } else {
      this.bookingService.bookVisit(date, time).subscribe((res) => {
        this.loader = false;
        if (res['msg']['success']) {
          swal("Done", "Booking Done Successfully", "success", {
            button: "Ok",
          });
          this.router.navigate(['/']);
        }
      }, (error) => {
        this.loader = false;
        this.msg = error['error']['message'];
      });

    }
  }

  ngOnInit(): void {
    this.pgService.hideSearchBar();
  }

}
