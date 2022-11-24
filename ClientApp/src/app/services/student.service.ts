import { HttpClient, HttpEvent, HttpHeaders, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})

export class StudentService {

    private baseApiUrl : string;
    private apiGetStudentUrl  : string;
    private tokenHeader = new HttpHeaders({'Authorization':'Bearer '+localStorage.getItem('token')})
    private studentEmail = JSON.parse(window.atob(localStorage.getItem('token').split('.')[1])).email;

    constructor(private httpClient: HttpClient) {
        this.baseApiUrl = 'https://localhost:44379';
        this.apiGetStudentUrl = this.baseApiUrl + '/api/Students/' + this.studentEmail;
    }

    public getStudent(): Observable<string[]> {
        
        return this.httpClient.get<string[]>(this.apiGetStudentUrl,{headers : this.tokenHeader});
    }

    public updateStudent(formData) {
        return this.httpClient.put(this.baseApiUrl + '/api/Students/' + this.studentEmail, formData);
    }
}
