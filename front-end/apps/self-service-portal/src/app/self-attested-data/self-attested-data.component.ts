import { Component } from '@angular/core';
import { AuthenticationService } from '@front-end/shared/authentication';

@Component({
  selector: 'self-service-self-attested-data',
  templateUrl: './self-attested-data.component.html',
  styleUrls: ['./self-attested-data.component.css']
})
export class SelfAttestedDataComponent {
  public dataAdded = false;

  constructor(private authenticationService: AuthenticationService) { }

  public get isAuthenticated(): boolean {
    return this.authenticationService.isAuthenticated;
  }

  onEmergencyContactDetailsAdded() {
    this.dataAdded = true;
  }

  hello() {
    console.log("TEST");
  }

  testEmit() {
    console.log("TEST");

  }
}
