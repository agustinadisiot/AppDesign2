import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginResponse } from 'src/app/models/loginResponse';
import { UserCredentials } from 'src/app/models/userCredentials';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  login(credentials: UserCredentials) {
    this.http.get<LoginResponse>("https://localhost:5002/login").subscribe(
      response => {
        return response;
      },
      error => {

      }
    );
  }
}
