import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pg-detail',
  templateUrl: './pg-detail.component.html',
  styleUrls: ['./pg-detail.component.css']
})
export class PgDetailComponent implements OnInit {

  constructor(private router: Router) { }

  close(){
    this.router.navigate(['']);
  }
  ngOnInit(): void {
  }

}
