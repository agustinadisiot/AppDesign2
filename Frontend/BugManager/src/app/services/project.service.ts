import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs';
import { Project } from 'src/app/models/Project';
import { environment } from 'src/environments/environment';
import { HttpErrorHandler } from './error-handler';

@Injectable({
  providedIn: 'root'
})
export class ProjectsService {
  endpoint = `${environment.webApi_origin}/projects`;
  options = { headers: { 'token': '', 'path': '' } };

  constructor(private http: HttpClient) { }

  getProjects(): any {
    this.options.headers.token = localStorage.getItem('token') || '';
    return this.http.get<Project[]>(this.endpoint, this.options).pipe(catchError(HttpErrorHandler.handleError));
  }

}
