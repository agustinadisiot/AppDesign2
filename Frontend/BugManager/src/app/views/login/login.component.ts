import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormControl, Validators, FormGroup } from '@angular/forms';
import { LoginService } from 'src/app/services/login/login.service';
import { UserCredentials } from 'src/app/models/userCredentials';
import { LoginResponse } from 'src/app/models/loginResponse';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  constructor(private router: Router, fb: FormBuilder, private loginService: LoginService) { }


  form = new FormGroup({
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required]),
  });

  credentials: UserCredentials = { username: '', password: '' } // TODO usar un modelo posta
  hide = true;


  ngOnInit() {
    localStorage.removeItem("role");
  }


  LogIn() {
    this.loginService.login(this.credentials).subscribe(
      (loginResponse: LoginResponse) => {
        //console.log(loginResponse)
        localStorage.setItem("role", loginResponse.role);
        this.router.navigateByUrl(`/${loginResponse.role}`);
        this.credentials = { username: '', password: '' };
      },
      error => {
        console.log(error) // TODO mostrar en pantalla
      }
    );

  }
}
