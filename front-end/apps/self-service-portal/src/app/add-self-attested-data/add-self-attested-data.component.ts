import { Component } from '@angular/core';
import { AuthenticationService } from '@front-end/shared/authentication';

@Component({
  selector: 'self-service-add-self-attested-data',
  templateUrl: './add-self-attested-data.component.html',
  styleUrls: ['./add-self-attested-data.component.css']
})
export class AddSelfAttestedDataComponent {

  constructor(private authenticationService: AuthenticationService) { }

  public get isAuthenticated(): boolean {
    return this.authenticationService.isAuthenticated;
  }

}


