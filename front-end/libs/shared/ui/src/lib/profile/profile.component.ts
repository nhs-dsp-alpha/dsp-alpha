import { Component, OnInit } from '@angular/core';
import { AuthenticationService, UserInfo } from '@front-end/shared/authentication';

@Component({
  selector: 'front-end-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent {

  constructor(private authentication: AuthenticationService) { }

  public get isAuthenticated(): boolean {
    return this.authentication.isAuthenticated;
  }
  
  public get user(): UserInfo | undefined {
    return this.authentication.user;
  }

  public get profile(): UserInfo | undefined {
    return this.authentication.userProfile;
  }

  public get welcome(): string {
    return this.user? `Digital staff passport for ${this.authentication.displayName}` : 'Welcome to Digital Staff Passport';
  }

  public login() {
    this.authentication.login();
  }

  public onPhotoChange() {
    console.log("Photo change requested");
    // this.authentication.profile();
  }

  public onEmailChange() {
    console.log("Email change requested");
    // this.authentication.profile();
  }

  public onNameChange() {
    this.authentication.profile();
  }
}