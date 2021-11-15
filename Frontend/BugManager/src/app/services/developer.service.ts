import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Developer } from '../models/Developer';
import { HttpErrorHandler } from './error-handler';

@Injectable({
  providedIn: 'root'
})
export class DeveloperService {
  endpoint = `${environment.webApi_origin}/devs`;

  constructor(private http: HttpClient) { }

  getDevelopers(): any {
    return this.http.get<Developer[]>(this.endpoint).pipe(catchError(HttpErrorHandler.handleError));
  }

}