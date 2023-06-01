import { Component, HostListener, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { StudentService } from '../services/student.service';
import * as p5 from 'p5';
import { Observable, ReplaySubject } from 'rxjs';
import { RequestService } from '../services/request.service';

@Component({
  selector: 'app-requests',
  templateUrl: './requests.component.html',
  styleUrls: ['./requests.component.css'],
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
        Adds:"",
        Files:[],
        SubjectsForm : [{}]
    }
    userDetails;
    strokeColor: number;
    canvas: any;
    selectedFiles: File[];
    byteArraySelectedFiles : any;
    subjectsData: any;

    subjectSelection = { };
    teachers = { };

    constructor(private studentService : StudentService, private indRequestService : RequestService, private toastr: ToastrService, private fb: FormBuilder,) { }

    ngOnInit() {
      this.getUser();
      this.getStudentSubject();

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

    private fillTeachers(){
      for (let i = 0; i < this.subjectsData.length; i++){
        for (let j = 0; j < this.subjectsData[i].teachers.length; j++){
          this.teachers[`${this.subjectsData[i].teachers[j].email}`] = this.subjectsData[i].teachers[j].name + this.subjectsData[i].teachers[j].surname + this.subjectsData[i].teachers[j].middleName 
        }
      }
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

    public getStudentSubject(){
      this.studentService.getStudentSubjects().subscribe(
        res => {
            this.subjectsData = res;
            console.log(this.subjectsData);
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

    public formSubjectsTable(){
      var table = document.querySelector("table tbody")
      var subjects = table.querySelectorAll('[name]') as any as Array<HTMLInputElement>;
      for (let i = 0; i < subjects.length; i++) {
        this.formModel.SubjectsForm[i] = {};
        this.formModel.SubjectsForm[i]["SubjectName"] = subjects[i].getAttribute("name");
        this.formModel.SubjectsForm[i]["Email"] = subjects[i].value.split("(")[1].slice(0, -1);
        this.formModel.SubjectsForm[i]["CombinedTeacherName"] = subjects[i].value.split("(")[0];
        console.log(subjects[i].value);
      }
      
    }

    onSubmitCreateRequest(form: NgForm) {
        var canvas = document.getElementById('defaultCanvas0') as HTMLCanvasElement;
        var src = canvas.toDataURL("image/png");
        form.value.Signature = src


        this.fillTeachers();
        console.log(this.teachers);

        this.formSubjectsTable();
        form.value.SubjectsForm = this.formModel.SubjectsForm;
        console.log(this.formModel.SubjectsForm);
        console.log(form.value);
        

        Promise.all(
          this.selectedFiles.map(
            (image) =>
              new Promise((resolve, reject) => {
                const fileReader = new FileReader();
  
                fileReader.onload = (file) => {
                  resolve(fileReader.result);
                };
  
                fileReader.onerror = (error) => reject(error);
  
                fileReader.readAsDataURL(image);
              })
          )
        ).then((base64Files) => {
          form.value.Files = base64Files;
          this.studentService.createStudentRequest(form.value).subscribe(
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
        });
      }

    trackByIndex(index, item) {
      return index;
    }

    filesAsStringArray() : string[] {
      var resultArray : string[] = [];
      for(let i = 0; i < this.selectedFiles.length; i++){
        this.createBase64StringFile(this.selectedFiles[i]).subscribe((res: any) =>{
          resultArray.push(res);
        })
      }
      console.log(resultArray);
      return resultArray;
    }

    filesAsByteArray(){
      let reader = new FileReader();
      reader.onload = function () {
        let arrayBuffer = reader.result as ArrayBuffer;
        let byteArray = new Uint8Array(arrayBuffer);
        console.log(byteArray); // Your byte array
      };
      for (let i = 0; i < this.selectedFiles.length; i++) {
        this.byteArraySelectedFiles.push(reader.readAsArrayBuffer(this.selectedFiles[i]));
      }
    }

    addToFormData(form: FormData) : FormData{
      for (let i = 0; i < this.selectedFiles.length; i++) {
        form.append("cert", this.selectedFiles[i]);
      }
      return form;
    }

    createBase64StringFile(file : File)  : Observable<string>{
        const result = new ReplaySubject<string>(1);
        const reader = new FileReader();
        reader.readAsBinaryString(file);
        reader.onload = (event) => result.next(btoa(reader.result.toString()));
        return result;
    }

    chooseFile(files: FileList) {
      this.selectedFiles = [];
      if (files.length === 0) {
        return;
      }
      for (let i = 0; i < files.length; i++) {
        this.selectedFiles.push(files[i]);
      }
    }
  }
