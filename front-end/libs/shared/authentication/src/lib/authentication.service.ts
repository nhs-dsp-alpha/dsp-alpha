import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, firstValueFrom, Observable, Subject } from 'rxjs';
import { Router } from '@angular/router';

import { ENV } from '../../../env';

@Injectable()
export class AuthenticationService {
  public currentUser?: UserInfo | undefined;
  private _isAuthenticated$: Subject<boolean> = new BehaviorSubject<boolean>(false);

  constructor(
    private http: HttpClient,
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    @Inject(ENV) private environment: any,
    private router: Router) {
  }

  public getUser<T>(): Promise<T> {
    const req = this.http.get<T>('user');
    return firstValueFrom(req);
  }

  public checkStatus(): Promise<void> {
    console.log('AuthenticationService:checkStatus');

    return this.getUser<UserInfo>()
      .then((user: UserInfo) => {
        this.currentUser = user;
        this._isAuthenticated$.next(true);
        console.log('user authenticated: ' + user.name);
      }).catch(error => {
        delete this.currentUser;
        this._isAuthenticated$.next(false);
        console.error(error);
      });
  }

  public get authenticationStatus(): Observable<boolean> {
    return this._isAuthenticated$;
  }

  public get isAuthenticated(): boolean {
    return !!this.currentUser;
  }

  public get userProfile(): UserInfo | undefined {
    return this.user ? {
      name: this.displayName,
      email: this.email,
      first_name: this.givenName,
      last_name: this.surname,
      identifier: ''
    } : undefined;
  }

  public get givenName(): string {
    return this.user ? this.user?.first_name || (this.user as any)["givenname"] || (this.user as any)["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname"] : '';
  }

  public get surname(): string {
    return this.user ? this.user?.last_name || (this.user as any)["surname"] || (this.user as any)["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname"] : '';
  }

  public get displayName(): string {
    return this.user ? (this.user as any)["displayName"] || `${this.givenName} ${this.surname}` : '';
  }

  public get email(): string {
    let email = '';

    if (this.user) {
      const emails = (this.user as any)["emails"];
      email = (Array.isArray(emails)) ? emails[0] : emails;
    }

    return email;
  }

  public get user(): UserInfo | undefined {
    return this.currentUser;
  }

  public get firstName(): string {
    return this.currentUser?.name || '';
  }

  public get lastName(): string {
    return this.currentUser?.name || '';
  }

  public authenticateUser(redirect: string): void {
    window.location.href = 'account?redirect=${redirect}';
  }

  public login() {
    this.navigateTo("login")
  }

  public logout() {
    this.router.navigateByUrl('/');
    this.navigateTo("logout")
  }

  public profile() {
    this.navigateTo("microsoftidentity/account/editprofile")
  }

  public password() {
    this.navigateTo("microsoftidentity/account/resetpassword")
  }

  private navigateTo(path: string) {
    const baseUrl = this.environment.redirectBaseUrl;
    const url = `${baseUrl}/${path.toLowerCase()}`;

    window.location.assign(url);
  }
}

export interface UserInfo {
  name: string;
  email: string;
  first_name: string;
  last_name: string;
  identifier: string;
}
