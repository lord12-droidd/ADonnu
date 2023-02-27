import { HttpClient, HttpEvent, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})

export class AdminService {

  private baseApiUrl : string;
  private apiGetUsersUrl  : string;
  private apiDeleteUrl  : string;
  private apiUpdateStudentUrl  : string;

  constructor(private httpClient: HttpClient) {
    this.baseApiUrl = 'https://localhost:44379';
    this.apiGetUsersUrl = this.baseApiUrl + '/api/Admins/Users';
    this.apiDeleteUrl = this.baseApiUrl + '/api/Admins/Delete/User';
    this.apiUpdateStudentUrl = this.baseApiUrl + '/api/Admins/Update/User';
   }

  public getUsers(): Observable<any[]> {
    return this.httpClient.get<any[]>(this.apiGetUsersUrl);
  }

  public getStudentForAdminEdit(email : string): Observable<string[]> {
    return this.httpClient.get<string[]>(this.baseApiUrl + '/api/Students/' + email);
  }

  public updateStudentByAdmin(email: string, formData) {
    return this.httpClient.put(this.baseApiUrl + '/api/Admins/Update/User?email=' + email, formData);
  }


  public deleteUser(email: string): Observable<HttpEvent<Blob>> {
    return this.httpClient.request(new HttpRequest(
      'DELETE',
      `${this.apiDeleteUrl}?email=${email}`,
      null,
      {
        reportProgress: true,
      }));
  }
}
