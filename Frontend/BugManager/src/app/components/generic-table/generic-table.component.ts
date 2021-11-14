import { Component, Input, EventEmitter, OnInit, Output } from '@angular/core';
import { Column } from './models/column';
import { ColumnType } from './models/columnTypes';

@Component({
  selector: 'app-generic-table',
  templateUrl: './generic-table.component.html',
  styleUrls: ['./generic-table.component.css']
})
export class GenericTableComponent implements OnInit {

  @Input() columns: Column[];
  @Input() dataSource: any[];
  @Input() displayedColumns: string[];
  columnsTypes = ColumnType;
  @Output() rowPressed = new EventEmitter();
  constructor() { }

  actions = new Map<string, any>([
    ["print", { fun: console.log, color: () => "primary", name: "Print this" }],
    ["alert", {
      fun: (a) => {
        alert(JSON.stringify(a));
      }, color: (a) => {
        if (a.name == "Bug1") return "blue";
        else return "red";
      }, name: "Changed Name"
    }],
    //["print", this.getAlertFunction]
  ]);

  // private getAlertFunction(b: object) {
  //   return {
  //     fun: alert(JSON.stringify(b))
  //   }
  // }

  ngOnInit(): void {
  }

  rowAction(row: any) {
    this.rowPressed.emit(row);
  }

}
