import { Component, Input, OnInit } from '@angular/core';
import { Developer } from 'src/app/models/Developer';
import { DeveloperService } from 'src/app/services/developer.service';
import { Display } from 'src/app/utils/display';
import { ButtonAction } from '../../generic-table/models/buttonAction';
import { Column } from '../../generic-table/models/column';
import { ColumnType } from '../../generic-table/models/columnTypes';

@Component({
  selector: 'app-devs-scoreboard',
  templateUrl: './devs-scoreboard.component.html',
  styleUrls: ['./devs-scoreboard.component.css']
})
export class DevsScoreboardComponent implements OnInit {

  @Input() dataSource: Developer[];
  @Input() buttonsColumns: Column[];
  @Input() buttonsActions: Map<string, ButtonAction>;

  columns: Column[] = [
    { header: "Username", property: "username", display: Display.id, type: ColumnType.Object },
    { header: "Name", property: "name", display: Display.id, type: ColumnType.Object },
    { header: "Lastname", property: "lastname", display: Display.id, type: ColumnType.Object },
    { header: "Email", property: "email", display: Display.id, type: ColumnType.Object },
    { header: "Cost", property: "cost", display: Display.CostPerHour, type: ColumnType.Object },
    { header: "Bugs Resolved", property: "bugsResolved", display: Display.id, type: ColumnType.Object },
  ]

  constructor(private devService: DeveloperService) { }

  ngOnInit(): void {
    //this.dataSource = this.devService.getDevelopers(); TODO
    this.dataSource = [
      {
        id: 1,
        username: "pepe123",
        name: "Juan",
        lastname: "González",
        email: "gonza@gmail.com",
        cost: 12,
        bugsResolved: 9
      },
      {
        id: 2,
        username: "asdf",
        name: "asdf",
        lastname: "asdf",
        email: "gonza@sdfail.com",
        cost: 111,
        bugsResolved: 999
      },
    ];
  }

}
