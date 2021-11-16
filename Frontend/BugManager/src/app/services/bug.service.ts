import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs';
import { Bug } from 'src/app/models/Bug';
import { environment } from 'src/environments/environment';
import { HttpErrorHandler } from './error-handler';

@Injectable({
  providedIn: 'root'
})
export class BugsService {
  endpoint = `${environment.webApi_origin}/bugs`;
  options = { headers: { 'token': '', 'path': '' } };

  constructor(private http: HttpClient) { }

  getBugs(): any {
    this.options.headers.token = localStorage.getItem('token') || '';
    console.log(this.options.headers)
    return this.http.get<Bug[]>(this.endpoint, this.options).pipe(catchError(HttpErrorHandler.handleError));
  }

  getBug(id: number): any {
    this.options.headers.token = localStorage.getItem('token') || '';
    return this.http.get<Bug>(`${this.endpoint}/${id}`, this.options).pipe(catchError(HttpErrorHandler.handleError));
  }

}
