import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { userroles } from '@front-end/shared/services';

@Injectable({
  providedIn: 'root'
})
export class VerifyStaffMemberGuard implements CanActivate {
  userRoles?: userroles.UserRoles;

  constructor(private userRolesService: userroles.UserRolesService){
    this.userRolesService.roles$.subscribe(roles => this.userRoles = roles);
  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      const index = this.userRoles ? this.userRoles.findIndex(s => s === "VerifyStaffMember") : -1;
      return index >= 0;
  }
}
