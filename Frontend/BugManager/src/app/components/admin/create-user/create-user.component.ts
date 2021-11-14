import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from 'src/app/models/User';
import { UserService } from 'src/app/services/user.service';
import { servicesVersion } from 'typescript';
import { InfoMessage } from '../../message/model/message';
import { Role } from './model/Role';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit {
  showCancelButton = false;
  hidePassword = true;
  loading = false;
  user: User = { username: '', name: '', lastname: '', email: '', password: '', id: 0 }
  infoMessage: InfoMessage = { error: true, text: '' };
  roles: Role[] = [
    { value: "admin", viewValue: "Admin" },
    { value: "tester", viewValue: "Tester" },
    { value: "dev", viewValue: "Developer" }, // TODO chequear si es dev o develoepr
  ]
  role: string = this.roles[0].value;

  constructor(private service: UserService) { }

  form = new FormGroup({
    username: new FormControl('', [Validators.required]),
    name: new FormControl('', [Validators.required]),
    lastname: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.email]),
    password: new FormControl('', [Validators.required]), // TODO add length
  });


  ngOnInit(): void {
  }

  save(): void {
    this.loading = true;
    this.service.createUser(this.user, this.role).subscribe(

      (response: any) => {
        this.loading = false;
        this.infoMessage.error = false;
        this.infoMessage.text = `User ${this.user.username} added successfully`
        this.form.reset();
        this.form.markAsUntouched();

      },

      error => {
        this.loading = false;
        this.infoMessage.error = true;
        this.infoMessage.text = error
      }
    );
  }

}
