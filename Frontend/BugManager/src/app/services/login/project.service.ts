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

  constructor(private http: HttpClient) { }

  getProjects(): any {
    return this.http.get<Project[]>(this.endpoint).pipe(catchError(HttpErrorHandler.handleError));
  }

}
