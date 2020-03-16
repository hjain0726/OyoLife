import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';


@Injectable()

export class PgService{

    applyGenderFilter=new Subject<string>();
    applyOccupancyFilter=new Subject<string>();
    applyMonthlyRentFilter=new Subject<{ start: number, end: number }>();
    applyLocationFilter=new Subject<string>();

    path = "https://localhost:44391";
    AllPGs:any;
    pg:any;
    
    constructor(private http: HttpClient){

    }

    getPGs() {
        return this.http.get(this.path + '/api/PGs');
    }

    genderFilter(gender:string){
        this.applyGenderFilter.next(gender);
    }

    occupancyFilter(occupancy:string){
        this.applyOccupancyFilter.next(occupancy);
    }

    monthlyRentFilter(obj){
        this.applyMonthlyRentFilter.next(obj);
    }

    locationFilter(location:string){
        this.applyLocationFilter.next(location);
    }

}