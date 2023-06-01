import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
  })
  
  export class SecretaryService {
  
      private baseApiUrl : string;
  
      constructor(private httpClient: HttpClient) {
          this.baseApiUrl = 'https://localhost:44379';
      }
  
      public getApprovedIndRequests() {
        return this.httpClient.get(this.baseApiUrl + '/api/IndScheduleRequest/Approved');
    }
  }