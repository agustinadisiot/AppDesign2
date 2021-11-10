import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}
export const ROUTES: RouteInfo[] = [ // EXP: Aca es donde van los links de la sidebar  
    { path: '/admin/dashboard', title: 'Dashboard',  icon: 'ni-tv-2 text-primary', class: '' },
    { path: '/admin/icons', title: 'Icons',  icon:'ni-planet text-blue', class: '' },
    { path: '/admin/maps', title: 'Maps',  icon:'ni-pin-3 text-orange', class: '' },
    { path: '/admin/user-profile', title: 'User profile',  icon:'ni-single-02 text-yellow', class: '' },
    { path: '/admin/tables', title: 'Tables',  icon:'ni-bullet-list-67 text-red', class: '' },
    { path: 'login', title: 'Logout',  icon:'ni-key-25 text-info', class: '' },
    { path: 'register', title: 'Register',  icon:'ni-circle-08 text-pink', class: '' }
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  public menuItems: any[];
  public isCollapsed = true;

  constructor(private router: Router) { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
    this.router.events.subscribe((event) => {
      this.isCollapsed = true;
   });
  }
}