import { Component, OnInit } from '@angular/core';
import { PgService } from '../pg/pg.service';

declare var $;

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.css']
})
export class SidenavComponent implements OnInit {

  constructor(private pgService:PgService) { }

  Gender(check:boolean,gender:string){
    if(check){
      this.pgService.genderFilter(gender);
    }else {
      this.pgService.genderFilter('');
    }
    
  }

  Occupancy(check:boolean,occupancy:string){
    if(check){
      this.pgService.occupancyFilter(occupancy);
    }else{
      this.pgService.occupancyFilter('');
    }
    
  }

  Rent(check:boolean,data){
    if(check){
      this.pgService.monthlyRentFilter(data);
    }else{
      this.pgService.monthlyRentFilter(null);
    }
    
  }
  
  ngOnInit(): void {
    $('input[type="checkbox"]').on('change', function () {
      $('input[name="' + this.name + '"]').not(this).prop('checked', false);
    });
  }

}
