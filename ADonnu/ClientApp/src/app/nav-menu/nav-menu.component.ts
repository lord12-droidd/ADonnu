import { Component, DoCheck, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { UserService } from '../services/registration.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  allRoles = ['Admin', 'Teacher', 'Student']
  currentUserRoles: [];
  displaymenu: boolean;
  isExpanded = false;

  constructor( private route: Router, private service: UserService) { }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  ngOnInit(): void {
    this.currentUserRoles = [];
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
      this.currentUserRoles = [];
      return;
    }
    this.currentUserRoles = JSON.parse(window.atob(token.split('.')[1])).roles.split(',')
  }
}
