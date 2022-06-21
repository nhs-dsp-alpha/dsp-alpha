import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IssueVerifyService } from './issue-verify/issue-verify.service';
import { ENV } from '../../../env';
import { OrganisationConnectionsService } from './organisation-connections/organisation-connections.service';

@NgModule({
  imports: [CommonModule],
})
export class SharedCredentialsModule {
  public static forRoot(environment: { redirectBaseUrl: string }): ModuleWithProviders<SharedCredentialsModule> {

    return {
        ngModule: SharedCredentialsModule,
        providers: [
          OrganisationConnectionsService,
          IssueVerifyService,
          {
              provide: ENV,
              useValue: environment
          }
        ]
    };
  }
}
