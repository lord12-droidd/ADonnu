import { Component, OnInit, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validator, Validators, ReactiveFormsModule } from "@angular/forms"
import { Router } from '@angular/router';
import { UserService } from '../services/registration.service';
import * as p5 from 'p5';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  
  constructor(public service: UserService, private toastr: ToastrService) { }
  
  ngOnInit() {
    this.service.formModel.reset();
    };
     

  onSubmit() {
    this.service.register().subscribe(
      (res: any) => {
        console.log(res);
        if (res["isCreated"] === true) {
          this.service.formModel.reset();
          this.toastr.success("Реєстрація успішна");
          console.log(res);
        }
      },
      err => {
        console.log(err);
        this.toastr.error("Реєстрація неуспішна");
      }
    );
  }
}
