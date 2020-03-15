import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {

  loader=false;
  emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$";
  msg:string;
  signinForm: FormGroup;

  constructor(private authService: AuthService,private router:Router) { }

  signIn() {
    this.loader=true;

    this.authService.signin(this.signinForm.value).subscribe((res) => {
      console.log(res);
      this.loader=false;
      localStorage.setItem("token", res['msg']['token']);
      localStorage.setItem("user_id", res['msg']['user_id']);
      if(res['msg']['success']){
        this.router.navigate(['/']);
      }
    },(error) => {
      this.loader = false;
      this.msg = error['error']['message'];
    });
  }

  ngOnInit(): void {
    this.signinForm = new FormGroup({
      'User_Email': new FormControl(null, [Validators.required, Validators.pattern(this.emailPattern)]),
      'User_Password': new FormControl(null, [Validators.required])
    });
  }

}
