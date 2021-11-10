import { Component, OnInit } from '@angular/core';

declare interface RouteInfo {
  path: string;
  title: string;
  icon: string;
}

export const ROUTES: RouteInfo[] = [ // EXP: Aca es donde van los links de la sidebar  
  { path: '/admin/bugs', title: 'Bugs 1', icon: 'bug_report' },
  { path: '/admin/bugs', title: 'Bugs 1', icon: 'bug_report' },
];


@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
