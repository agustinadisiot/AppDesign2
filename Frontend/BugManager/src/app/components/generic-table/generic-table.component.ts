import { Component, Input, EventEmitter, OnInit, Output } from '@angular/core';
import { Column } from './models/column';

@Component({
  selector: 'app-generic-table',
  templateUrl: './generic-table.component.html',
  styleUrls: ['./generic-table.component.css']
})
export class GenericTableComponent implements OnInit {

  @Input() columns: Column[];
  @Input() dataSource: any[];
  @Input() displayedColumns: string[];

  @Output() rowPressed = new EventEmitter();
  constructor() {
    // this.displayedColumns = this.columns.map(function (c) { return c.header }); TODO sacar
  }

  ngOnInit(): void {
  }

  rowAction(row: any) {
    this.rowPressed.emit(row);
  }

}
