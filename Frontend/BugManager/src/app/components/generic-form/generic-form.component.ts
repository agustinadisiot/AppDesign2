import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { InfoMessage } from '../message/model/message';

@Component({
  selector: 'app-generic-form',
  templateUrl: './generic-form.component.html',
  styleUrls: ['./generic-form.component.css']
})
export class GenericFormComponent implements OnInit {
  @Input() title: string = "Form";
  @Input() form: FormGroup = new FormGroup({});
  @Input() errorMessage: InfoMessage = { error: false, text: "" }
  @Input() showCancelButton: boolean = true;

  @Output() save = new EventEmitter();
  @Output() cancel = new EventEmitter();

  loading = false;
  clickOnSave() {
    this.loading = true;
    this.save.emit();
    this.loading = false;
  }


  constructor() { }

  ngOnInit(): void {
  }


}
