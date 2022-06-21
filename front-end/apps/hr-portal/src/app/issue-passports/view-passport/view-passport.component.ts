import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { organisationIssuer, container, issuing, IssuableCredentials } from '@front-end/shared/services';

@Component({
  selector: 'hr-portal-view-passport',
  templateUrl: './view-passport.component.html',
  styleUrls: ['./view-passport.component.css']
})
export class ViewPassportComponent implements OnInit {

  private id?: string;

  credentialsIssued = false;

  public request?: issuing.ConnectionRequest = undefined;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: organisationIssuer.OrganisationIssuerService,
    private issuableService: IssuableCredentials.IssuableCredentialsService,
    private container: container.ContainerService
  ) {
  }

  ngOnInit() {
    this.request = history.state;
    this.route.paramMap.subscribe(paramMap => {
      this.id = paramMap.get('id')?.toString();
      console.log(this.id);
    })
  }


  onIssueCredentialClicked() {
    const credentialRequest: organisationIssuer.CredentialRequest = this.createCreds("PrimaryIdentityCredential", "PostOffice", "{\"Surname\":\"Schmidt\",\"GivenNames\":\"Kasper\",\"DateOfBirth\":\"1987-05-05\",\"Telephone\":\"07700900359\",\"EmailAddress\":\"kasper.schmidt22@example.com\",\"ProfileImageUrl\":\"https:\/\/nhsuk-dsp-prototype.herokuapp.com\/images\/profile-pic-kasper.png\"}", "authority");

    this.service.GetCredentialResponse(credentialRequest).subscribe(
      x => {
        // This returns the JWT Credential for the user. Currently set to expire in 12 months.
        const body: IssuableCredentials.IssuableRequest = {
          portalUserId: this.request?.portalUserId,
          sentAt: new Date(),
          message: JSON.stringify(x),
          messageType: 'Issuable',
        }
        this.issuableService.requestPost(body).subscribe(x => {
          console.log(x);
          this.credentialsIssued = true;
        });
      }
    )
  }


  createCreds(credentialType: string, issuer: string, sub: string, authority: string): organisationIssuer.CredentialRequest {
    return {
      "credentialType": credentialType,
      "issuer": issuer,
      "sub": sub,
      "authority": authority
    }
  }
}