import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IParamsBackLink } from '@front-end/shared/ui';
import { organisations, credentialTypes, issuer } from '@front-end/shared/services';
import { firstValueFrom, map, Observable } from 'rxjs';

@Component({
  selector: 'self-service-share-passport',
  templateUrl: './share-passport.component.html',
  styleUrls: ['./share-passport.component.css']
})
export class SharePassportComponent implements OnInit {
  backlink: IParamsBackLink = { href: undefined, routerLink: '/', text: 'Back', clickable: true };

  public organisationsFound = false;
  public organisationSelected = false;
  public dateOfBirthAdded = false;
  public credentialsSelected = false;
  public credentialsVerified = false;
  public busy = false;
  public summarySent = false;

  selectedOrganisation?: organisations.Organisation;
  selectedOrganisationCode = '';
  dob?: Date;
  selectedCredentials: credentialTypes.CredentialType[] = [];
  message = '';
  verifiedCredentials = '';

  public get organisations$(): Observable<organisations.Organisation[]> {
    return this.organisationsService.organisations$.pipe(map(orgs => this.filterOrganisations(orgs)));
  }

  private filterOrganisations(organisations: organisations.Organisation[]) {
    return organisations.filter(o => o.name);
  }

  constructor
    (private organisationsService: organisations.OrganisationsService,
      private router: Router,
      private issuerService: issuer.IssuerService,
  ) { }

  ngOnInit(): void {
    this.organisationsService.getList();
  }

  returnHome() {
    this.router.navigate(["/"]);
  }

  onOrganisationsFound(done: boolean) {
    this.organisationsFound = done;
  }

  onOrganisationCodeSelected(code: string) {
    this.selectedOrganisationCode = code;
    firstValueFrom(this.organisations$.pipe(map(orgs => orgs.filter(o => o.code == code))))
      .then(o => {
        this.selectedOrganisation = o.length ? o[0] : undefined;
        console.log(this.selectedOrganisation);
      });
  }

  onOrganisationSelected(done: boolean) {
    this.organisationSelected = done;
  }

  onDateOfBirthAdded(dob: Date) {
    this.dob = dob;
    this.dateOfBirthAdded = true;
  }

  onCredentialTypesSelected(selectedCredentials: credentialTypes.CredentialType[]) {
    this.selectedCredentials = selectedCredentials;
  }
  onMessageSet(message: string) {
    this.message = message;
  }
  onReverifyCredentials(reverify: boolean) {
    this.credentialsSelected = true;
    if (reverify) {
      this.credentialsVerified = false;
    }
  }

  onCredentialsVerified(results: string) {
    this.verifiedCredentials = results;
    this.credentialsVerified = true;
  }


  onChangeOrganisation() {
    this.organisationSelected = false;
  }

  onChangeDob() {
    this.dateOfBirthAdded = false;
  }

  onChangeSharedInformation() {
    // Could reuse message - Going to have to check if they change what credentials are selected
    this.credentialsSelected = false;
  }

  onChangeMessage() {
    // Going to have to check if they change what credentials are selected
    this.credentialsSelected = false;
  }

  onSummaryFormContinue(done: boolean) {
    if (done) {
      const sub =
        [
          { key: "dob", value: this.dob ? this.dob.toUTCString() : '' },
          { key: "verifiedCredentials", value: this.verifiedCredentials },
          { key: "message", value: this.message }
        ];

      const request: issuer.ConnectionRequest = { sub, organisationCode: this.selectedOrganisationCode };

      console.log("Connection request...");
      this.busy = true;
      this.issuerService.connect(request)
        .then(() => {
          this.busy = false;
          console.log("Sent");
          this.summarySent = true;
        });
    }
  }
}
