import { Component, OnInit } from '@angular/core';
import { AuthenticationService, UserInfo } from '@front-end/shared/authentication';
import { OperatorFunction } from 'rxjs';

@Component({
  selector: 'front-end-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {
  public signedInStatus = '';

  constructor(private authentication: AuthenticationService) { }

  ngOnInit(): void {
    this.authentication.authenticationStatus.subscribe(
      data => {
        this.signedInStatus = data ? "You are signed in" : "You are not signed in";
      });
  }

  setAuth(): OperatorFunction<boolean, unknown> {
    throw new Error('Method not implemented.');
  }

  public get isAuthenticated(): boolean {
    return this.authentication.isAuthenticated;
  }

  public get welcome(): string {
    return this.authentication.user? `Digital staff passport for ${this.displayName}` : 'Welcome to Digital Staff Passport';
  }

  public get displayName(): string {
    return this.authentication.user? `${(this.authentication.user as any)["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname"]} ${(this.authentication.user as any)["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname"]}` : '';
  }

  public get user(): string {
    return this.authentication.user ? `Hello ${(this.authentication.user as any)["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname"]}` : '';
  }

  public login() {
    this.authentication.login();
  }

  public logout() {
    this.authentication.logout();
  }

  public profile() {
    this.authentication.profile();
  }

  public password() {
    this.authentication.password();
  }
}
