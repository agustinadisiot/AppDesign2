import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Bug } from 'src/app/models/Bug';
import { Display } from 'src/app/utils/display';
import { InfoMessage } from '../message/model/message';

@Component({
  selector: 'app-bug-form',
  templateUrl: './bug-form.component.html',
  styleUrls: ['./bug-form.component.css']
})
export class BugFormComponent implements OnInit {
  loading = false;

  infoMessage: InfoMessage = { error: true, text: '' };
  form = new FormGroup({
    name: new FormControl('', [Validators.required]),
    description: new FormControl('', [Validators.required]),
    version: new FormControl('', [Validators.required]),
    project: new FormControl('', [Validators.required]),
    time: new FormControl('', [Validators.required]),
    isActive: new FormControl('', [Validators.required])
  });

  projects: any[] = [
    { value: 1, viewValue: "Admin" },
    { value: 2, viewValue: "Tester" },
    { value: 3, viewValue: "Developer" }
  ];
  projectId: number = this.projects[0].value;

  devs: any[] = [
    { value: 1, viewValue: "Admin" },
    { value: 2, viewValue: "Tester" },
    { value: 3, viewValue: "Developer" },
  ]
  dev: number;

  display = Display.IsActiveAsResolve;
  bug: Bug = { name: '', description: '', version: '', time: 0, projectId: 0, projectName: '', isActive: true }
  constructor(private route: ActivatedRoute) { }


  ngOnInit(): void {
    let param1 = this.route.snapshot.queryParams["id"];
    console.log(param1)

  }

  save() {

  }
}
