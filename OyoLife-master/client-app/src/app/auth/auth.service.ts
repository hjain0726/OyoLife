import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';


@Injectable()

export class AuthService {

    path = "https://localhost:44391";

    constructor(private http: HttpClient,private router:Router) {

    }

    signup(user) {
        return this.http.post(this.path + '/api/Users/Register', user);
    }

    signin(user) {
        return this.http.post(this.path + '/api/Users/Signin', user);
    }

    // check token is present or not
    isAuthenticated() {
        return localStorage.getItem("token") != null;
    }

    //logout
    logout() {
        localStorage.clear();
        this.router.navigate(['/signin']);
    }
}