import { Component } from '@angular/core';
import { faBars } from '@fortawesome/free-solid-svg-icons';
import { PlayerDataService } from '../_data-services/playerDataService';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  faBars = faBars;
  
  /**
   *
   */
  constructor(public playerDataService : PlayerDataService) {
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  

  logout(){
    localStorage.clear();
    sessionStorage.clear();
    location.reload();
  }
}
