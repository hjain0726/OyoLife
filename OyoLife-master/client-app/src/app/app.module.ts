import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
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
import { AuthService } from './auth/auth.service';
import { AuthGuard } from './auth/auth-guard.service';
import { AuthInterceptor } from './auth/auth.interceptor';
import { GenderPipe } from './filters/gender.pipe';
import { OccupancyPipe } from './filters/occupancy.pipe';
import { MonthlyRentPipe } from './filters/MonthlyRent.pipe';
import { LocationPipe } from './filters/location.pipe';
import { BookingService } from './visit-booking/booking.service';

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
    VistBookingComponent,
    GenderPipe,
    OccupancyPipe,
    MonthlyRentPipe,
    LocationPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [PgService,
    BookingService,
    AuthService,
    AuthGuard,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
