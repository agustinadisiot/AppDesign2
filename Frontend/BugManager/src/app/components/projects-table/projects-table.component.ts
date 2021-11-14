import { Component, Input, OnInit } from '@angular/core';
import { Project } from 'src/app/models/Project';
import { Display } from 'src/app/utils/display';
import { ButtonAction } from '../generic-table/models/buttonAction';
import { Column } from '../generic-table/models/column';
import { ColumnType } from '../generic-table/models/columnTypes';

@Component({
  selector: 'app-projects-table',
  templateUrl: './projects-table.component.html',
  styleUrls: ['./projects-table.component.css']
})
export class ProjectsTableComponent implements OnInit {

  @Input() dataSource: Project[];
  @Input() buttonsColumns: Column[];
  @Input() buttonsActions: Map<string, ButtonAction>;


  columns: Column[] = [
    { header: "Name", property: "name", display: Display.id, type: ColumnType.Object },
    { header: "No.", property: "id", display: Display.id, type: ColumnType.Object },
  ]
  displayedColumns = ["id", "name"];

  constructor() { }

  ngOnInit(): void {
    this.declareButtonsInHeader();
  }

  declareButtonsInHeader() {
    this.buttonsColumns.forEach((column: Column) => {
      this.columns.push(column);
    })
  }

}
