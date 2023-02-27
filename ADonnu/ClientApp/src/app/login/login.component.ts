import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';
import { UserService } from '../services/registration.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  formModel = {
    Email: '',
    Password: ''
  }
  constructor(private service: UserService, private router: Router, private toastr: ToastrService) { }
  
  ngOnInit() {
    if (localStorage.getItem('token') != null)
      this.router.navigateByUrl('');
  }

  onSubmit(form: NgForm) {
    this.service.login(form.value).subscribe(
      (res: any) => {
        localStorage.setItem('token', res.token);
        this.service.updatemenu.next();
        this.router.navigate(['']);
        this.toastr.success("Вхід виконано");
      },
      err => {
        this.toastr.error("Неправильний логін чи пароль");
      }
    );
  }
}
