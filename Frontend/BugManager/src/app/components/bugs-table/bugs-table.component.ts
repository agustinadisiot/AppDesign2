import { Component, Input, OnInit } from '@angular/core';
import { Bug } from 'src/app/models/Bug';
import { Display } from 'src/app/utils/display';
import { ButtonAction } from '../generic-table/models/buttonAction';
import { Column } from '../generic-table/models/column';
import { ColumnType } from '../generic-table/models/columnTypes';

@Component({
  selector: 'app-bugs-table',
  templateUrl: './bugs-table.component.html',
  styleUrls: ['./bugs-table.component.css']
})
export class BugsTableComponent implements OnInit {

  @Input() dataSource: Bug[];
  @Input() buttonsColumns: Column[];
  @Input() buttonsActions: Map<string, ButtonAction>;

  bugsColumn: Column[] = [
    { header: "Name", property: "name", display: Display.id, type: ColumnType.Object },
    { header: "Description", property: "description", display: Display.id, type: ColumnType.Object },
    { header: "Project", property: "projectName", display: Display.id, type: ColumnType.Object },
    { header: "Version", property: "version", display: Display.id, type: ColumnType.Object },
    { header: "Time", property: "time", display: Display.id, type: ColumnType.Object },
    { header: "State", property: "isActive", display: Display.IsActiveAsResolve, type: ColumnType.Object },
    { header: "Completed By", property: "completedByName", display: Display.NullableString, type: ColumnType.Object },
    { header: "Project Id", property: "projectId", display: Display.id, type: ColumnType.Object },
    { header: "Id", property: "id", display: Display.id, type: ColumnType.Object },
    { header: "Completed By (Id)", property: "completedById", display: Display.id, type: ColumnType.Object },
    { header: "Edit", property: "edit", display: Display.id, type: ColumnType.Button },
    { header: "Delete", property: "delete", display: Display.id, type: ColumnType.Button },
  ]
  displayedColumns = ["name", "description", "projectName", "version", "time", "isActive", "completedByName"];

  constructor() { }

  ngOnInit(): void {
    ;

  }

}
