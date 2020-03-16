import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()

export class BookingService{
    pg:any;
    path = "https://localhost:44391";

    constructor(private http: HttpClient){

    }

    bookVisit(date,time){
        let booking={
            Booking_Date:date,
            Booking_Time:time,
            PGId:this.pg.id,
            DealerId:this.pg.dealerId,
            UserId:parseInt(localStorage.getItem("user_id")),
        }
        return this.http.post(this.path + '/api/Bookings',booking);
    }
}