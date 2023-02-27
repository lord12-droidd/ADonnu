import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { StudentService } from '../services/student.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
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
    }
    userDetails;

    constructor(private studentService : StudentService, private toastr: ToastrService, private fb: FormBuilder,) { }

    ngOnInit() {
      this.getUser();
    }

    private outputStudentInfo(userDetails){
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
    }


    private getUser() {
      let userRoles = JSON.parse(window.atob(localStorage.getItem('token').split('.')[1])).roles.split(',');
      if (userRoles.includes('Student')){
        this.getStudent();
        return;
      }
      this.getTeacher();

    }

    private onSubmitUpdate(form: NgForm) {
      this.studentService.updateStudent(form.value).subscribe(
        (res: any) => {
          this.toastr.success("Оновлено");
        },
        err => {
          this.toastr.error("Не вдалось оновити користувача");
        }
      );
    }

    private getStudent(){
      this.studentService.getStudent().subscribe(
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

    private getTeacher(){

    }

}