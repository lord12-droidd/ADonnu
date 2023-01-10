import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './auth/auth.guard';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LogoutComponent } from './logout/logout.component';
import { AccountComponent } from './account/account.component';
import { RequestsComponent } from './requests/requests.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    RegistrationComponent,
    ForbiddenComponent,
    LogoutComponent,
    AccountComponent,
    RequestsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'registration', component : RegistrationComponent},
      { path: 'login', component : LoginComponent},
      { path: 'forbidden', component : ForbiddenComponent},
      { path: 'logout', component : LogoutComponent},
      { path: 'account', component : AccountComponent, canActivate:[AuthGuard], data :{permittedRoles:['Student']}},
      { path: 'requests', component : RequestsComponent, canActivate:[AuthGuard], data :{permittedRoles:['Student']}}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
