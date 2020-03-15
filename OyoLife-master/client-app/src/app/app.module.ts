import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";


import { AppComponent } from './app.component';
import { NavbarComponent } from './core/navbar/navbar.component';
import { SidenavComponent } from './sidenav/sidenav.component';
import { PgListComponent } from './pg/pg-list/pg-list.component';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './core/home/home.component';
import { SigninComponent } from './auth/signin/signin.component';
import { SignupComponent } from './auth/signup/signup.component';
import { PgDetailComponent } from './pg/pg-detail/pg-detail.component';
import { VistBookingComponent } from './visit-booking/vist-booking.component';
import { PgService } from './pg/pg.service';
import { from } from 'rxjs';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    SidenavComponent,
    PgListComponent,
    HomeComponent,
    SigninComponent,
    SignupComponent,
    PgDetailComponent,
    VistBookingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [PgService],
  bootstrap: [AppComponent]
})
export class AppModule { }
