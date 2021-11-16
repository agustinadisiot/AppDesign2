import { Component, OnInit } from '@angular/core';
import { Column } from '../../generic-table/models/column';
import { ColumnType } from '../../generic-table/models/columnTypes';
import { ButtonAction } from '../../generic-table/models/buttonAction';
import { Project } from 'src/app/models/Project';
import { Router } from '@angular/router';
import { ProjectsService } from 'src/app/services/project.service';
import { Display } from 'src/app/utils/display';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css']
})
export class ProjectsComponent implements OnInit {

  dataSource: Project[];
  loading = true;

  buttonsColumns: Column[] = [
    { header: "Testers", property: "testers", display: Display.id, type: ColumnType.Button },
    { header: "Developers", property: "devs", display: Display.id, type: ColumnType.Button },
    { header: "Edit Name", property: "edit", display: Display.id, type: ColumnType.Button },
    { header: "Delete", property: "delete", display: Display.id, type: ColumnType.Button },
  ]

  buttonsActions = new Map<string, ButtonAction>([
    ["testers", { text: "Testers", onClick: this.tester, color: () => "accent" }],
    ["devs", { text: "Developers", onClick: this.developers, color: () => "accent" }],
    ["edit", { text: "Edit", onClick: this.edit, color: () => "primary" }],
    ["delete", { text: "Delete", onClick: this.delete, color: () => "warn" }],
  ]);

  constructor(private router: Router, private projectService: ProjectsService) { }

  edit(project) {
    alert(JSON.stringify(project));
    // TODO
  }

  tester(project) {
    alert(JSON.stringify(project));
    // TODO
  }

  developers(project) {
    alert(JSON.stringify(project));
    // TODO
  }
  delete(project) {
    alert(JSON.stringify(project));
    // TODO
  }

  ngOnInit(): void {
    this.loading = true;
    this.projectService.getProjects().subscribe(

      (response: Project[]) => {
        this.loading = false;
        this.dataSource = response;
      },

      error => {
        this.loading = false;
        // TODO mostrar error
      }
    );
  }
}
