import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, share } from 'rxjs';
import { DefaultService, UserRoles } from "./api";

export { UserRoles } from "./api";

@Injectable()
export class UserRolesService {
  private _roles$ = new BehaviorSubject<UserRoles>([]);

  constructor(private service: DefaultService) { }

  public get roles$(): Observable<UserRoles> {
    return this._roles$.pipe(share());
  }

  public getRoles(): Observable<UserRoles> {
    this.service.getroles("", "")
      .subscribe(data => this._roles$.next(data));
    return this.roles$;
  }
}
