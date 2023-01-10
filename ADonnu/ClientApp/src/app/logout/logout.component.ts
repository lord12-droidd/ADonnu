import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { RegistrationService } from "../services/registration.service";

@Component({
    template: ''
  })
  
  export class LogoutComponent implements OnInit {
  
    constructor(private service: RegistrationService, private router: Router) {}
  
    ngOnInit() {
        if (localStorage.getItem('token') != null){
            localStorage.removeItem('token')
            this.service.updatemenu.next();
            this.router.navigateByUrl('');
        }    
    }
}