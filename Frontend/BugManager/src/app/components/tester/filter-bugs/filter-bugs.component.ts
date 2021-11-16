import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Bug } from 'src/app/models/Bug';

interface Filters {
  id?: number,
  projectName?: string,
  bugName?: string,
  status?: boolean,
}

@Component({
  selector: 'app-filter-bugs',
  templateUrl: './filter-bugs.component.html',
  styleUrls: ['./filter-bugs.component.css']
})
export class FilterBugsComponent implements OnInit {

  dataSource: Bug[];
  filteredBugs: Bug[];

  filters: Filters = {};

  selectionOptions = [
    { value: null, viewValue: "Any" },
    { value: false, viewValue: "Resolved" },
    { value: true, viewValue: "Unresolved" },
  ]
  selectedOption = this.selectionOptions[0].value;

  form = new FormGroup({
    id: new FormControl('', []),
    projectName: new FormControl('', []),
    bugName: new FormControl('', []),
    state: new FormControl('', []),
  });

  constructor() {
  }

  ngOnInit(): void {
    //this.dataSource = this.bugsServices.getBugs(); TODO
    this.dataSource = [{
      name: "Bug1 Tester",
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
    }, {
      name: "nombre",
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
    this.filteredBugs = this.dataSource;
  }

  applyFilter() {
    let tempFilteredBug: Bug[] = [];
    tempFilteredBug = this.dataSource;
    if (this.filters.id != undefined)
      tempFilteredBug = this.dataSource.filter(b => b.id == this.filters.id);

    tempFilteredBug = tempFilteredBug.filter(b => b.projectName.toLowerCase().includes(this.filters.projectName?.toLowerCase() || ""));
    tempFilteredBug = tempFilteredBug.filter(b => b.name.toLowerCase().includes(this.filters.bugName?.toLowerCase() || ""));

    if (this.filters.status != undefined)
      tempFilteredBug = tempFilteredBug.filter(b => b.isActive == this.filters.status);

    this.filteredBugs = tempFilteredBug;
  }

  clearFilter() {
    this.filters = {};
    this.filteredBugs = this.dataSource;
  }

}
