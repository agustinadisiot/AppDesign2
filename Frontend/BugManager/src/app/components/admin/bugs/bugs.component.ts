import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Bug } from 'src/app/models/Bug';
import { BugsService } from 'src/app/services/bug.service';
import { Display } from 'src/app/utils/display';
import { ButtonAction } from '../../generic-table/models/buttonAction';
import { Column } from '../../generic-table/models/column';
import { ColumnType } from '../../generic-table/models/columnTypes';

@Component({
  selector: 'app-bugs',
  templateUrl: './bugs.component.html',
  styleUrls: ['./bugs.component.css']
})
export class BugsComponent implements OnInit {

  dataSource: Bug[];
  buttonsColumns: Column[] = [
    { header: "Edit", property: "edit", display: Display.id, type: ColumnType.Button },
    { header: "Delete", property: "delete", display: Display.id, type: ColumnType.Button },
  ]
  constructor(private router: Router, private bugsServices: BugsService) { }

  buttonsActions = new Map<string, ButtonAction>([
    ["edit", { text: "Edit", onClick: this.editBug, color: () => "primary" }],
    ["delete", { text: "Delete", onClick: this.deleteBug, color: () => "warn" }],
  ]);


  editBug(bug) {
    alert(JSON.stringify(bug));
    // TODO
  }

  deleteBug(bug) {
    alert(JSON.stringify(bug));
    // TODO
  }

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
  }

}
