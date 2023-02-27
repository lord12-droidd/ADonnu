import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AdminService } from '../services/admin.service';
import { DataService } from '../services/data.service';
import { UserService } from '../services/registration.service';
import { StudentService } from '../services/student.service';

@Component({
  selector: 'app-editStudent',
  templateUrl: './editStudent.component.html',
  styleUrls: ['./editStudent.component.css']
})
export class EditStudentComponent implements OnInit {
  formModel = {
    Email: '',
    Name: '',
    Surname:'',
    MiddleName:'',
    Course: '',
    Group: '',
    Faculty: '',
    EducationForm: '',
    FinancingForm: '',
    EducationDegree: '',
    StudentRole: false,
    AdminRole: false,
    TeacherRole: false
  }
  userDetails;

  constructor(private dataService: DataService, private adminService : AdminService, private toastr: ToastrService, private router: Router) { }

  ngOnInit() {
    this.getUser();
  }

  get userToEdit() : any {
    return this.dataService.adminToEditSharedData;
  }

  public outputStudentInfo(userDetails){
      this.formModel.Email = userDetails.email;
      this.formModel.Name = userDetails.name;
      this.formModel.Surname = userDetails.surname;
      this.formModel.MiddleName = userDetails.middleName;
      this.formModel.Course = userDetails.course;
      this.formModel.Group = userDetails.group;
      this.formModel.Faculty = userDetails.faculty;
      this.formModel.EducationForm = userDetails.educationForm;
      this.formModel.FinancingForm = userDetails.financingForm;
      this.formModel.EducationDegree = userDetails.educationDegree;
      if (this.userToEdit.roles.includes('Student')){
        this.formModel.StudentRole = true;
      }
      if (this.userToEdit.roles.includes('Admin')){
        this.formModel.AdminRole = true;
      }
      if (this.userToEdit.roles.includes('Teacher')){
        this.formModel.TeacherRole = true;
      }
      
  }


  public getUser() {
    if (this.userToEdit === undefined){
      this.router.navigateByUrl('/admin');
      return;
    }
    console.log(this.userToEdit);
    let userRoleToGet = this.userToEdit.roles;
    if (userRoleToGet.includes('Student')){
      this.getStudent(this.userToEdit.email);
      return;
    }
    this.getTeacher();

  }

  private getStudent(email : string){
    this.adminService.getStudentForAdminEdit(email).subscribe(
      res => {
          this.userDetails = res;
          this.outputStudentInfo(this.userDetails)
          console.log(this.userDetails);
      },
      err => {
          console.log(err);
      },
    );
  }

  private onSubmitUpdate(form: NgForm) {
    if (this.userToEdit.roles.includes('Student')){
      this.adminService.updateStudentByAdmin(this.userToEdit.email, form.value).subscribe(
        (res: any) => {
          this.toastr.success("Оновлено");
        },
        err => {
          this.toastr.error("Не вдалось оновити користувача");
        }
      );
    }

  }

  private getTeacher(){

  }

}