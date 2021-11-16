import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Bug } from 'src/app/models/Bug';
import { BugsService } from 'src/app/services/bug.service';
import { Display } from 'src/app/utils/display';
import { ButtonAction } from '../generic-table/models/buttonAction';
import { Column } from '../generic-table/models/column';
import { ColumnType } from '../generic-table/models/columnTypes';

@Component({
  selector: 'app-bugs',
  templateUrl: './bugs.component.html',
  styleUrls: ['./bugs.component.css']
})
export class BugsComponent implements OnInit {

  @Input() dataSource: Bug[];
  buttonsColumns: Column[] = [
    { header: "Edit", property: "edit", display: Display.id, type: ColumnType.Button },
    { header: "Delete", property: "delete", display: Display.id, type: ColumnType.Button },
  ]
  constructor(private router: Router, private r: ActivatedRoute, private bugsServices: BugsService) { }

  buttonsActions = new Map<string, ButtonAction>([
    ["edit", { text: "Edit", onClick: (b) => { this.editBug(b) }, color: () => "primary" }],
    ["delete", { text: "Delete", onClick: this.deleteBug, color: () => "warn" }],
  ]);


  editBug(bug) {
    this.router.navigate(["../bug"], { relativeTo: this.r, queryParams: { id: String(bug.id) } });
  }

  deleteBug(bug) {
    alert(JSON.stringify(bug));
    // TODO
  }

  ngOnInit(): void {
  }

}
