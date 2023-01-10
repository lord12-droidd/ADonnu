import { HttpClient, HttpEvent, HttpHeaders, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})

export class StudentService {

    private baseApiUrl : string;

    constructor(private httpClient: HttpClient) {
        this.baseApiUrl = 'https://localhost:44379';
    }

    public getStudent(): Observable<string[]> {
        let studentEmail = JSON.parse(window.atob(localStorage.getItem('token').split('.')[1])).email;

        return this.httpClient.get<string[]>(this.baseApiUrl + '/api/Students/' + studentEmail);
    }

    public updateStudent(formData) {
        let studentEmail = JSON.parse(window.atob(localStorage.getItem('token').split('.')[1])).email;
        return this.httpClient.put(this.baseApiUrl + '/api/Students/' + studentEmail, formData);
    }
}
