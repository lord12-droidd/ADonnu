import { Component, DoCheck, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { RegistrationService } from '../services/registration.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  displayStudent = false;
  displayTeacher = false;
  displaySecretary = false;
  currentrole: any;
  someSubscription: any;
  displayGuest = true;
  displaymenu: boolean;
  constructor( private route: Router, private service: RegistrationService) { }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  ngOnInit(): void {
    this.service.updatemenu.subscribe(res => {
      this.MenuDisplay();
    });
    this.MenuDisplay();
  }
  ngDoCheck(): void {
    if (this.route.url == '/login') {
      this.displaymenu = false
    } else {
      this.displaymenu = true
    }
  }

  MenuDisplay() {
    var token = localStorage.getItem('token');
    if (token === null){
      this.displayGuest = true;
      this.displayStudent = false;
      this.displayTeacher = false;
      this.displaySecretary = false;
      return
    }
    var payLoad = JSON.parse(window.atob(token.split('.')[1]));
    this.currentrole = payLoad.role;
    if (this.currentrole === "Student"){
      this.displayGuest = false;
      this.displayStudent = true;
      this.displayTeacher = false;
      this.displaySecretary = false;
    }
    else if (this.currentrole === "Teacher"){
      this.displayGuest = false;
      this.displayStudent = false;
      this.displayTeacher = true;
      this.displaySecretary = false;
    }
    else if (this.currentrole === "Secretary"){
      this.displayGuest = false;
      this.displayStudent = false;
      this.displayTeacher = false;
      this.displaySecretary = true;
    }
  }
}
