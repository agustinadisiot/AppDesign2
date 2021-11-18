import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs';
import { Assignment } from 'src/app/models/Assignment';
import { environment } from 'src/environments/environment';
import { HttpErrorHandler } from './error-handler';

@Injectable({
    providedIn: 'root'
  })
  export class AssignmentService {
    endpoint = `${environment.webApi_origin}/works`;
    options = { headers: { 'token': '', 'path': '' } };
  
    constructor(private http: HttpClient) { }
  
    getAssignments(): any {
      this.options.headers.token = localStorage.getItem('token') || '';
      return this.http.get<Assignment[]>(this.endpoint, this.options).pipe(catchError(HttpErrorHandler.handleError));
    }
}