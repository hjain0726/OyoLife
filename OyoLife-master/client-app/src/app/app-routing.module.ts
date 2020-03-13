import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { PgComponent } from './pg/pg.component';
import { HomeComponent } from './core/home/home.component';
import { SigninComponent } from './auth/signin/signin.component';
import { SignupComponent } from './auth/signup/signup.component';
import { PgDetailComponent } from './pg-detail/pg-detail.component';
import { VistBookingComponent } from './visit-booking/vist-booking.component';

const appRoutes: Routes = [
    {
        path: '', component: HomeComponent, children: [
            { path: '', component: PgComponent }
        ]
    },
    { path: 'signin', component: SigninComponent },
    { path: 'signup', component: SignupComponent },
    { path: 'PgDetail', component: PgDetailComponent },
    { path: 'VisitBooking', component: VistBookingComponent }
];

@NgModule({
    exports: [
        RouterModule
    ],
    imports: [
        RouterModule.forRoot(appRoutes)
    ]
})
export class AppRoutingModule {

}