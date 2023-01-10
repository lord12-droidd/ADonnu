import { HttpClient, HttpEvent, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})

export class RequestService {

    private baseApiUrl : string;

    constructor(private httpClient: HttpClient) {
        this.baseApiUrl = 'https://localhost:44379';
    }

    public createStudentRequest(formData) {
        return this.httpClient.post(this.baseApiUrl + '/api/IndScheduleRequest', formData,{
            reportProgress: true,
            responseType: 'blob'
          });
    }
}