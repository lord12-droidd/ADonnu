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

    public uploadIndRequestAdds(formData) {
      console.log(formData);
      let studentEmail = JSON.parse(window.atob(localStorage.getItem('token').split('.')[1])).email;
      return this.httpClient.post(this.baseApiUrl + '/api/IndScheduleRequest/Adds', formData);
  }
}