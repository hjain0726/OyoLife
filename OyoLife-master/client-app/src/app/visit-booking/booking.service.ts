import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()

export class BookingService{
    pg:any;
    path = "https://localhost:44391";

    constructor(private http: HttpClient){

    }

    bookVisit(booking){
        return this.http.post(this.path + '/api/Bookings',booking);
    }
}