import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '@front-end/shared/authentication';

@Component({
  selector: 'self-service-accept-credential',
  templateUrl: './accept-credential.component.html',
  styleUrls: ['./accept-credential.component.css']
})
export class AcceptCredentialComponent implements OnInit {

  constructor(private authenticationService: AuthenticationService) { }

  numberOfCredentials = 1;

  public get isAuthenticated(): boolean {
    return this.authenticationService.isAuthenticated;
  }

  ngOnInit(): void {
    console.log();
  }

}
