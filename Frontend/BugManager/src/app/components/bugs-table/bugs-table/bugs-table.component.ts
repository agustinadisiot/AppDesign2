import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Bug } from 'src/app/models/Bug';
import { BugsService } from 'src/app/services/login/bug.service';
import { Display } from 'src/app/utils/display';
import { Column } from '../../generic-table/models/column';

@Component({
  selector: 'app-bugs-table',
  templateUrl: './bugs-table.component.html',
  styleUrls: ['./bugs-table.component.css']
})
export class BugsTableComponent implements OnInit {

  @Input() dataSource: Bug[];

  bugsColumn: Column[] = [
    { header: "Name", property: "name", display: x => x },
    { header: "Description", property: "description", display: x => x },
    { header: "Project", property: "projectName", display: x => x },
    { header: "Version", property: "version", display: x => x },
    { header: "Time", property: "time", display: x => x },
    { header: "State", property: "isActive", display: Display.displayIsActiveAsResolve },
    { header: "Completed By", property: "completedByName", display: Display.displayStringNull },
    { header: "Project Id", property: "projectId", display: x => x },
    { header: "Id", property: "id", display: x => x },
    { header: "Completed By (Id)", property: "completedById", display: x => x },
  ]

  displayedColumns = ["name", "description", "projectName", "version", "time", "isActive", "completedByName"]
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
    ]
  }

  rowPressed(row) {
    // TODO ir a editar bug/eliminar
  }
}
