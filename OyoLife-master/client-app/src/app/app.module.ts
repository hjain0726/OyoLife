import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NavbarComponent } from './core/navbar/navbar.component';
import { SidenavComponent } from './sidenav/sidenav.component';
import { PgComponent } from './pg/pg.component';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './core/home/home.component';
import { SigninComponent } from './auth/signin/signin.component';
import { SignupComponent } from './auth/signup/signup.component';
import { PgDetailComponent } from './pg-detail/pg-detail.component';
import { VistBookingComponent } from './visit-booking/vist-booking.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    SidenavComponent,
    PgComponent,
    HomeComponent,
    SigninComponent,
    SignupComponent,
    PgDetailComponent,
    VistBookingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
