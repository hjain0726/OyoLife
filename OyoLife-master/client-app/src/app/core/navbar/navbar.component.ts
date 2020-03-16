import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from 'src/app/auth/auth.service';
import { PgService } from 'src/app/pg/pg.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  @ViewChild('srch',{static:true}) searched;

  constructor(private authService: AuthService,private pgService:PgService) { }

  search(){
    this.pgService.locationFilter(this.searched.nativeElement.value);
  }

  isAuthenticated() {
    return this.authService.isAuthenticated();
  }

  logout(){
    this.authService.logout();
  }

  ngOnInit(): void {
  }

}
