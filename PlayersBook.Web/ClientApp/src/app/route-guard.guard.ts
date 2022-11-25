import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { PlayerDataService } from './_data-services/player-Data.Service';

@Injectable({
  providedIn: 'root'
})
export class RouteGuardGuard implements CanActivate {
  /**
   *
   */
  constructor(private playerDataService: PlayerDataService) {
    
  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      console.log("Entrou no canActivate")
    return this.playerDataService.userLogged();
  }
  
}
