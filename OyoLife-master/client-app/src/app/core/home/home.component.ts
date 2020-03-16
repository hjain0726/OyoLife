import { Component, OnInit } from '@angular/core';
import { PgService } from 'src/app/pg/pg.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private pgService:PgService) { }

  ngOnInit(): void {
    this.pgService.showSearchBar();
  }

}
