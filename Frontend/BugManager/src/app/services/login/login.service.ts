import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginResponse } from 'src/app/models/loginResponse';
import { UserCredentials } from 'src/app/models/userCredentials';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  endpoint = `${environment.webApi_origin}/login`;

  constructor(private http: HttpClient) { }

  login(credentials: UserCredentials) {
    this.http.get<LoginResponse>(this.endpoint).subscribe(
      response => {
        return response;
      },
      error => {

      }
    );
  }
}
