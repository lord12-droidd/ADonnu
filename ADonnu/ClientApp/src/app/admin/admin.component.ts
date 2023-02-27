import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AdminService } from '../services/admin.service';
import { UserService } from '../services/registration.service';
import { Router } from '@angular/router';
import { DataService } from '../services/data.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  public users: any[];
  currentAdminEmail : string;

  get userToEdit():any {
    return this.dataService.adminToEditSharedData;
  }

  set userToEdit(value: any){
    this.dataService.adminToEditSharedData = value;
  }

  constructor(private service : AdminService, private userService : UserService, private toastr: ToastrService, private router: Router, private dataService: DataService) { }

  ngOnInit() {
    this.getUsers();
    this.currentAdminEmail = JSON.parse(window.atob(localStorage.getItem('token').split('.')[1])).email;
  }
  getUsers() {
    this.service.getUsers().subscribe(
      data => {
        this.users = data;
        console.log(data);
      }
    );
  }

  private deleteUser(email : string){
    console.log(email);
    if(this.currentAdminEmail !== email){
      this.service.deleteUser(email).subscribe();
      this.removeElementFromArray(email);
      return;
    }
    this.toastr.info("You can`t delete yourself")
  }

  private editUser (user) {
    this.userToEdit = user;
    if (user.roles.includes('Student')){
      this.router.navigateByUrl('/edit/student');
      return;
    }
    this.router.navigateByUrl('/edit/teacher');
  };

  private removeElementFromArray(element: string) {
    this.users.forEach((value,index)=>{
        if(value.email==element) {
          this.users.splice(index,1);
        }
    });
  }

}