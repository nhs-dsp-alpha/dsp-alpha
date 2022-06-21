import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { credentialTypes } from '@front-end/shared/services';
import { IParamsBackLink } from '@front-end/shared/ui';
import { IssueVerifyService } from '@front-end/shared/credentials';

@Component({
  selector: 'self-service-share-passport-verify-credentials',
  templateUrl: './share-passport-verify-credentials.component.html',
  styleUrls: ['./share-passport-verify-credentials.component.css']
})
export class SharePassportVerifyCredentialsComponent {
  @Input()
  public selectedCredentials: credentialTypes.CredentialType[] = [];
  @Output()
  public cancel = new EventEmitter<boolean>();
  @Output()
  public continue = new EventEmitter<string>();

  backlink: IParamsBackLink = { href: undefined, routerLink: '#', text: 'Back', clickable: true };

  constructor(private issueVerifyService: IssueVerifyService) { }

  showVerify(credentialType: string, credentialIssuer: string) {
    this.issueVerifyService.ShowVerify(credentialType, credentialIssuer)
      .then(path => this.showResult(path));
  }

  private async showResult(path: string) {
    this.continue.emit(path);
  }

  goBack() {
    this.cancel.emit(true);
    return false;
  }

}
