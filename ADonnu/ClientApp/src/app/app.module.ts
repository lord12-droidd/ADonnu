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
import { AdminComponent } from './admin/admin.component';
import { EditStudentComponent } from './editStudent/editStudent.component';
import { DataService } from './services/data.service';
import { NgSelectModule } from '@ng-select/ng-select';
import { ApproveComponent } from './approve/approve.component';
import { SecretaryComponent } from './secretary/secretary.component';

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
    RequestsComponent,
    AdminComponent,
    EditStudentComponent,
    ApproveComponent,
    SecretaryComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    NgSelectModule, 
    FormsModule,
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
      { path: 'requests', component : RequestsComponent, canActivate:[AuthGuard], data :{permittedRoles:['Student']}},
      { path: 'admin', component : AdminComponent, canActivate:[AuthGuard], data :{permittedRoles:['Admin']}},
      { path: 'edit/student', component : EditStudentComponent},
      { path: 'approve', component: ApproveComponent, canActivate:[AuthGuard], data :{permittedRoles:['Teacher']}},
      { path: 'requests/approved', component: SecretaryComponent, canActivate:[AuthGuard], data :{permittedRoles:['Secretary']}}
    ])
  ],
  providers: [DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
