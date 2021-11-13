import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { LoginResponse } from 'src/app/views/login/models/loginResponse';
import { UserCredentials } from 'src/app/models/userCredentials';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  endpoint = `${environment.webApi_origin}/login`;

  constructor(private http: HttpClient) { }

  login(credentials: UserCredentials): any { // Observable<LoginResponse>
    return this.http.post<LoginResponse>(this.endpoint, credentials).pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) { // TODO mover a una funcionar a parte para que todos puedan usar la misma 

    if (error.status === 0)
      return throwError("Server is shut down")

    const possibleErrorCodes = [404, 400, 401, 500]
    if (possibleErrorCodes.includes(error.status))
      return throwError(error.error.responseMessage)

    return throwError("Server with problems");
  }
}
