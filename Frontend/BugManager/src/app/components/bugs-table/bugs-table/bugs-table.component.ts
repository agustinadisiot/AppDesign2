import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Bug } from 'src/app/models/Bug';
import { BugsService } from 'src/app/services/login/bug.service';
import { Display } from 'src/app/utils/display';
import { Column } from '../../generic-table/models/column';
import { ColumnType } from '../../generic-table/models/columnTypes';

@Component({
  selector: 'app-bugs-table',
  templateUrl: './bugs-table.component.html',
  styleUrls: ['./bugs-table.component.css']
})
export class BugsTableComponent implements OnInit {

  @Input() dataSource: Bug[];

  bugsColumn: Column[] = [
    { header: "Name", property: "name", display: Display.id, type: ColumnType.Object },
    { header: "Description", property: "description", display: Display.id, type: ColumnType.Object },
    { header: "Print", property: "print", display: Display.id, type: ColumnType.Button },
    { header: "Alert", property: "alert", display: Display.id, type: ColumnType.Button },
    { header: "Project", property: "projectName", display: Display.id, type: ColumnType.Object },
    { header: "Version", property: "version", display: Display.id, type: ColumnType.Object },
    { header: "Time", property: "time", display: Display.id, type: ColumnType.Object },
    { header: "State", property: "isActive", display: Display.IsActiveAsResolve, type: ColumnType.Object },
    { header: "Completed By", property: "completedByName", display: Display.NullableString, type: ColumnType.Object },
    { header: "Project Id", property: "projectId", display: Display.id, type: ColumnType.Object },
    { header: "Id", property: "id", display: Display.id, type: ColumnType.Object },
    { header: "Completed By (Id)", property: "completedById", display: Display.id, type: ColumnType.Object },
  ]

  displayedColumns = ["name", "description", "projectName", "version", "time", "isActive", "completedByName", "print", "alert"]
  constructor(private router: Router, private bugsServices: BugsService) { }

  ngOnInit(): void {
    //this.dataSource = this.bugsServices.getBugs(); TODO
    this.dataSource = [{
      name: "Bug1",
      description: "Descripcion bug1",
      version: "1.0",
      time: 12,
      projectId: 3,
      projectName: "nombre del proyecto",
      id: 1,
      isActive: true,
    }, {
      name: "Bug 2",
      description: "Descripcion bug2",
      version: "3.4",
      time: 9999,
      projectId: 2,
      projectName: "Nombre del proyecto 2",
      id: 2,
      isActive: false,
      completedById: 2,
      completedByName: "Juancito"
    },
    ];
    // (this.dataSource[0] as any).otherProperty = 'hello';
    // console.log(this.dataSource[0]);
    // console.log(typeof this.dataSource[0]);


  }

  rowPressed(row) {
    // TODO ir a editar bug/eliminar
  }
}
