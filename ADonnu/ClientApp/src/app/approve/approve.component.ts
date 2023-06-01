import { Component, OnInit } from '@angular/core';
import * as p5 from 'p5';
import { TeacherService } from '../services/teacher.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-home',
  templateUrl: './approve.component.html',
  styleUrls: ['./approve.component.css']
})
export class ApproveComponent implements OnInit {
  constructor(private service : TeacherService, private toastr: ToastrService) { }

  students : any;
  strokeColor: number;
  canvas: any;

  ngOnInit() {
    this.getUsers();


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

  getUsers() {
    this.service.getTeacherIndScheduleRequests().subscribe(
      data => {
        this.students = data;
        console.log(data);
      }
    );
  }

  public clearCanvas()
  {
    var canvas = document.getElementById('defaultCanvas0') as HTMLCanvasElement
    let ctx = canvas.getContext("2d");
    ctx.clearRect(0, 0, canvas.width, canvas.height);
  }

  private approveRequest(email : string, index){
    
    if (this.getComment(email, index).length > 15){
      this.toastr.info("Максимальна довжина графіку відпрацювання 15 символів");
      return;
    }

    var body = {};
    var canvas = document.getElementById('defaultCanvas0') as HTMLCanvasElement;
    var src = canvas.toDataURL("image/png");
    body["Signature"] = src;
    body["Comment"] = this.getComment(email, index);
    

    this.service.approveStudentRequest(email, body).subscribe(
        (res: any) => {
        this.removeElementFromArray(email);
        this.toastr.success("Узгоджено");
      },
      err => {
        this.toastr.error("Виникла помилка при узгодженні заяви");
      });
  }

  private removeElementFromArray(element: string) {
    this.students.forEach((value,index)=>{
        if(value.email==element) {
          this.students.splice(index,1);
          console.log(this.students);
        }
    });
  }

  private getComment(email : string, index) : string{
    var table = document.querySelector("table tbody")
    var comments = table.querySelectorAll('[name]') as any as Array<HTMLInputElement>;
    for (let i = 0; i < comments.length; i++){
      if (comments[i].getAttribute("name").split(">")[0] === email && comments[i].getAttribute("name").split(">")[1] == index){
        return comments[i].value;
      }
    }
  }
}

