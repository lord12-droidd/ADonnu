import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { RequestService } from '../services/request.service';
import { StudentService } from '../services/student.service';
import * as p5 from 'p5';

@Component({
  selector: 'app-requests',
  templateUrl: './requests.component.html',
  styleUrls: ['./requests.component.css']
})
export class RequestsComponent implements OnInit {
    formModel = {
        Email: '',
        Name: '',
        Surname:'',
        MiddleName:'',
        Phone:'',
        Course: '',
        Group: '',
        Faculty: '',
        EducationForm: '',
        FinancingForm: '',
        Speciality: "",
        EducationDegree: '',
        Reason: "",
        StartDate:"",
        EndDate: "",
        Adds:""
    }
    userDetails;
    strokeColor: number;
    canvas: any;

    constructor(private studentService : StudentService, private requestService : RequestService, private toastr: ToastrService, private fb: FormBuilder,) { }

    ngOnInit() {
      this.getUser();

      const sketch = s => {
        s.setup = () => {
          let canvas2 = s.createCanvas(s.windowWidth - 200, s.windowHeight - 200);
          // creating a reference to the div here positions it so you can put things above and below
          // where the sketch is displayed
          canvas2.parent('sketch-holder');
        
          s.background(255);
          
          s.strokeWeight(0);
          s.rect(0, 0, s.width, s.height);
        
          s.stroke(s.color(0, 0, 0));
          var canvas = document.getElementById('defaultCanvas0') as HTMLCanvasElement;
          canvas.style.width  = '100%';
          canvas.style.height = '100%';
        };
        
        s.draw = () => {
          if (s.mouseIsPressed) {
            if (s.mouseButton === s.LEFT) {
              s.line(s.mouseX, s.mouseY, s.pmouseX, s.pmouseY);
              s.strokeWeight(15);
            } else if (s.mouseButton === s.CENTER) {
              s.background(255);
            }
          }
        };
      };
        
      this.canvas = new p5(sketch);
    }

    public outputStudentInfo(userDetails){
        this.formModel.Email = userDetails.email;
        this.formModel.Name = userDetails.name;
        this.formModel.Surname = userDetails.surname;
        this.formModel.MiddleName = userDetails.middleName;
        this.formModel.Phone = userDetails.phone;
        this.formModel.Course = userDetails.course;
        this.formModel.Group = userDetails.group;
        this.formModel.Faculty = userDetails.faculty;
        this.formModel.EducationForm = userDetails.educationForm;
        this.formModel.FinancingForm = userDetails.financingForm;
        this.formModel.Speciality = userDetails.speciality;
        this.formModel.EducationDegree = userDetails.educationDegree;
    }


    public getUser() {
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

    public clearCanvas()
    {
      var canvas = document.getElementById('defaultCanvas0') as HTMLCanvasElement
      let ctx = canvas.getContext("2d");
      ctx.clearRect(0, 0, canvas.width, canvas.height);
    }

    onSubmitCreateRequest(form: NgForm) {
        var canvas = document.getElementById('defaultCanvas0') as HTMLCanvasElement;
        var src = canvas.toDataURL("image/png");
        form.value.Signature = src
        this.requestService.createStudentRequest(form.value).subscribe(
          (res: any) => {
            console.log(form.value);
            console.log(res);
            const fileName: string = 'Сформовані заяви на інд. графік.pdf';
            const objectUrl: string = URL.createObjectURL(res);
            const a: HTMLAnchorElement = document.createElement('a') as HTMLAnchorElement;
        
            a.href = objectUrl;
            a.download = fileName;
            document.body.appendChild(a);
            a.click();        
        
            document.body.removeChild(a);
            URL.revokeObjectURL(objectUrl);
            this.toastr.success("Заява створена");
          },
          err => {
            this.toastr.error("Виникла помилка при створенні заяви");
          }
        );
      }

}