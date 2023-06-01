import { HttpClient, HttpEvent, HttpHeaders, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})

export class TeacherService {

    private baseApiUrl : string;

    constructor(private httpClient: HttpClient) {
        this.baseApiUrl = 'https://localhost:44379';
    }

    public getTeacherIndScheduleRequests(): Observable<string[]> {
        let teacherEmail = JSON.parse(window.atob(localStorage.getItem('token').split('.')[1])).email;
        return this.httpClient.get<string[]>(this.baseApiUrl + '/api/Teachers/' + teacherEmail + "/Students/IndScheduleRequests");
    }

    public approveStudentRequest(studentEmail : string, body) {
        let teacherEmail = JSON.parse(window.atob(localStorage.getItem('token').split('.')[1])).email;
        return this.httpClient.post(this.baseApiUrl + '/api/IndScheduleRequest/' + teacherEmail + "/Approve/Student/" + studentEmail, body);
    }

}