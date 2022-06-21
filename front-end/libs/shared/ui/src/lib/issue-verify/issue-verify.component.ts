import { Component } from '@angular/core';
import { AuthenticationService } from '@front-end/shared/authentication';

import { IssueVerifyService } from '@front-end/shared/credentials';

@Component({
  selector: 'front-end-issue-verify',
  templateUrl: './issue-verify.component.html',
  styleUrls: ['./issue-verify.component.scss']
})
export class IssueVerifyComponent {
  public result?: string;

  constructor(
    private authentication: AuthenticationService,
    private service: IssueVerifyService) { }

  public get isAuthenticated(): boolean {
    return this.authentication.isAuthenticated;
  }

  public showIssue() {
    this.service.ShowIssue()
      .then(path => this.showResult(path));
  }

  public showVerify() {
    this.service.ShowVerify()
      .then(path => this.showResult(path));
  }

  private async showResult(path: string) {
    this.result = path;
  }
}
