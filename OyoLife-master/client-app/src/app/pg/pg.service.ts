import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';


@Injectable()

export class PgService{

    path = "https://localhost:44391";
    AllPGs:any;
    pg:any;
    
    constructor(private http: HttpClient){

    }

    getPGs() {
        return this.http.get(this.path + '/api/PGs');
    }

}