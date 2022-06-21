import { Injectable } from '@angular/core';
import { AuthenticationService } from '@front-end/shared/authentication';
import { userroles } from '@front-end/shared/services';
import { Observable } from 'rxjs';
import { B2CUser } from './api';

export enum dspRoles {
  None,
  WardManager,
  HR,
  OH
}

@Injectable({
  providedIn: 'root'
})
export class NhsUserService {
  public currentUser?: B2CUser;

  constructor(
    private authService: AuthenticationService,
    /*private userRolesService: userroles.UserRolesService*/) { }

  public getUser(): Promise<B2CUser | undefined> {
    return this.authService.getUser<B2CUser>()
      .then((user) => {
        // this.userRolesService.getRoles();
        user = this.keysToCamel(user);
        this.currentUser = user;
        console.log('user authenticated: ' + user.name);
        console.log('User:', user);
        console.log('user Activities:', this.cis2Activities);
        console.log('user Activity Codes:', this.cis2ActivityCodes);
        return user;
      }).catch(error => {
        delete this.currentUser;
        console.error(error);
        return undefined;
      });
  }

  // public get userRoles$(): Observable<userroles.UserRoles> {
  //   return this.userRolesService.roles$;
  // }

  public get dspRole(): dspRoles {
    const codes = this.cis2RoleCodes;
    return codes.length == 0 ? dspRoles.None
    : codes.findIndex(c => c === "S0010:G0020:R0260") >= 0 ? dspRoles.WardManager
    : codes.findIndex(c => c === "S8000:G8000:R8000") >= 0 ? dspRoles.None
    : codes.findIndex(c => c === "S8001:G8002:R8008") >= 0 ? dspRoles.OH
    : codes.findIndex(c => c === "S0080:G0450:R5080") >= 0 ? dspRoles.OH
    : dspRoles.None;
  }

  public get cis2RoleNames() {
    return this.currentUser?.nrbacRoles ? this.currentUser?.nrbacRoles?.map(r => r.roleName)
      : [];
  }

  public get cis2RoleCodes() {
    return this.currentUser?.nrbacRoles ? this.currentUser?.nrbacRoles?.map(r => r.roleCode)
      : [];
  }

  public get cis2Activities() {
    return this.currentUser?.nrbacRoles ? this.currentUser?.nrbacRoles?.map(r => r.activities)
      .reduce((previous, current) => {
        return (current) ? previous?.concat(current) : previous;
      }, [])
      : [];
  }

  public get cis2ActivityCodes() {
    return this.currentUser?.nrbacRoles ? this.currentUser?.nrbacRoles?.map(r => r.activityCodes)
      .reduce((previous, current) => {
        return (current) ? previous?.concat(current) : previous;
      }, [])
      : [];
  }

  toCamel(s: string): string {
    return s.replace(/([-_][a-z])/ig, ($1) => {
      return $1.toUpperCase()
        .replace('-', '')
        .replace('_', '');
    });
  }

  keysToCamel<T>(o: any): T {
    if (o === Object(o) && !Array.isArray(o) && typeof o !== 'function') {
      const n: { [key: string]: any } = {};
      Object.keys(o).forEach((k) => {
        n[this.toCamel(k)] = this.keysToCamel(o[k]);
      });
      return n as T;
    } else if (Array.isArray(o)) {
      return o.map((i) => {
        return this.keysToCamel(i);
      }) as unknown as T;
    }

    return o;
  }

  keysToCamel1<T>(o: any): T {
    if (o === Object(o) && !Array.isArray(o) && typeof o !== 'function') {
      const n: any = {};
      Object.keys(o)
        .forEach((k) => {
          n[this.toCamel(k)] = this.keysToCamel(o[k]);
        });
      return n as T;
    } else if (Array.isArray(o)) {
      return o.map((i) => {
        return this.keysToCamel(i);
      }) as unknown as T;
    }
    return o;
  }
}
