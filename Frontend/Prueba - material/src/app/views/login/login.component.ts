import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormControl, Validators, FormGroup } from '@angular/forms';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  constructor(private router: Router, fb: FormBuilder) { }


  form = new FormGroup({
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required]),
  });

  user = { username: '', password: '' } // TODO usar un modelo posta
  hide = true;


  ngOnInit() {
  }


  LogIn() {
    // TODO validate credentials
    this.router.navigateByUrl('/nav');
    //this.user = { username: '', password: '' }; TODO sacar
  }
}
