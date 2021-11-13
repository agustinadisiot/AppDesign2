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

  constructor(private http: HttpClient) { }

  getBugs(): any {
    return this.http.get<Bug[]>(this.endpoint).pipe(catchError(HttpErrorHandler.handleError));
  }

}
