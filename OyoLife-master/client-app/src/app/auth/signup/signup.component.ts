import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { PgService } from 'src/app/pg/pg.service';

declare var swal: any;

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  loader = false;
  emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$";
  phoneNumber = "^(\\+\\d{1,3}[- ]?)?\\d{10}$";
  msg: string;
  signupForm: FormGroup;

  constructor(private authService: AuthService, private router: Router,private pgService:PgService) { }

  signUp() {
    this.loader = true;

    this.authService.signup(this.signupForm.value).subscribe((res) => {
      this.loader = false;
      console.log(res);
      if (res['msg']['success']) {
        this.router.navigate(['/signin']);
        //alert("Account created Successfully");
        swal("Done", "Account Created Successfully", "success", {
          button: "Ok",
        });
      }
    }, (error) => {
      this.loader = false;
      this.msg = error['error']['message'];
    });
  }

  ngOnInit(): void {

    this.signupForm = new FormGroup({
      'User_Email': new FormControl(null, [Validators.required, Validators.pattern(this.emailPattern)]),
      'User_Password': new FormControl(null, [Validators.required]),
      'user_name': new FormControl(null, [Validators.required]),
      'user_gender': new FormControl(null, [Validators.required]),
      'user_age': new FormControl(null, [Validators.required]),
      'user_phone': new FormControl(null, [Validators.required, Validators.pattern(this.phoneNumber)]),
    });
    this.signupForm.controls['user_gender'].setValue("Male", { onlySelf: true });

    this.pgService.hideSearchBar();
  }

}
