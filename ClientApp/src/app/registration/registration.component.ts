import { Component, OnInit, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validator, Validators, ReactiveFormsModule } from "@angular/forms"
import { Router } from '@angular/router';
import { RegistrationService } from '../services/registration.service';
import * as p5 from 'p5';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  strokeColor: number;
  canvas: any;

  
  constructor(public service: RegistrationService, private toastr: ToastrService) { }
  
  ngOnInit() {
    this.service.formModel.reset();

    const sketch = s => {
      s.setup = () => {
        let canvas2 = s.createCanvas(s.windowWidth - 200, s.windowHeight - 200);
        // creating a reference to the div here positions it so you can put things above and below
        // where the sketch is displayed
        canvas2.parent('sketch-holder');
     
        s.background(255);
        s.strokeWeight(10);
        
        s.rect(0, 0, s.width, s.height);
     
        s.stroke(s.color(0, 0, 0));
        var canvas = document.getElementById('defaultCanvas0') as HTMLCanvasElement;
        var src = canvas.toDataURL("image/png");
        //let canvasUrl = canvas2.toDataURL();
        console.log(src);
        //console.log(canvasUrl);
      };
     
      s.draw = () => {
        if (s.mouseIsPressed) {
          if (s.mouseButton === s.LEFT) {
            s.line(s.mouseX, s.mouseY, s.pmouseX, s.pmouseY);
          } else if (s.mouseButton === s.CENTER) {
            s.background(255);
          }
        }
      };
    };
     
    this.canvas = new p5(sketch);
  }
  sw(sw: any) {
    throw new Error('Method not implemented.');
  }

  onSubmit() {
    this.service.register().subscribe(
      (res: any) => {
        console.log(res);
        if (res["isCreated"] === true) {
          this.service.formModel.reset();
          this.toastr.success("Регістрація успішна");
          console.log(res);
        }
      },
      err => {
        console.log(err);
        this.toastr.error("Регістрація неуспішна");
      }
    );
  }


}
