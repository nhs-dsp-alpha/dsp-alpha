import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import * as config from './configuration';
import * as organisations from './organisations';
import * as issuer from './issuer';
import * as issuing from './issuing';
import * as userroles from './user-roles';
import * as msgraph from './microsoft-graph';
import * as container from './container';
import * as credentialTypes from './credential-types';
import * as passportListDummy from './passport-list-dummy';
import * as orgissuer from './organisation-issuer';
import * as IssuableCredentials from './issuable-credentials';

@NgModule({
  imports: [
    CommonModule,
    organisations.ApiModule.forRoot(() => new organisations.Configuration({ withCredentials: true })),
    issuer.ApiModule.forRoot(() => new issuer.Configuration({ withCredentials: true })),
    issuing.ApiModule.forRoot(() => new issuer.Configuration({ withCredentials: true })),
    msgraph.ApiModule.forRoot(() => new msgraph.Configuration({ withCredentials: true })),
    orgissuer.ApiModule.forRoot(() => new orgissuer.Configuration({ withCredentials: true })),
    container.ApiModule.forRoot(() => new container.Configuration({ withCredentials: true })),
    IssuableCredentials.ApiModule.forRoot(() => new IssuableCredentials.Configuration({ withCredentials: true })),
  ],
  exports: [
  ]
})
export class SharedServicesModule {
  public static forRoot(environment: { redirectBaseUrl: string, apiPath: string }): ModuleWithProviders<SharedServicesModule> {
    const base_url = (environment.redirectBaseUrl && environment.redirectBaseUrl.length) ? environment.redirectBaseUrl : window.location.origin;

    return {
      ngModule: SharedServicesModule,
      providers: [
        config.service.ConfigurationService,
        credentialTypes.service.CredentialTypesService,
        credentialTypes.service.CredentialTypesService,
        passportListDummy.service.PassportListDummyService,
        organisations.service.OrganisationsService,
        {
          provide: organisations.BASE_PATH,
          useValue: new URL(`${environment.apiPath}/${organisations.apiPath}`, base_url).toString()
        },
        issuer.service.IssuerService,
        {
          provide: issuer.BASE_PATH,
          useValue: new URL(`${environment.apiPath}/${issuer.apiPath}`, base_url).toString()
        },
        issuing.service.IssuingService,
        {
          provide: issuing.BASE_PATH,
          useValue: new URL(`${environment.apiPath}/${issuing.apiPath}`, base_url).toString()
        },
        userroles.service.UserRolesService,
        {
          provide: userroles.BASE_PATH,
          useValue: new URL(`${environment.apiPath}/${userroles.apiPath}`, base_url).toString()
        },
        msgraph.service.MicrosoftGraphService,
        {
          provide: msgraph.BASE_PATH,
          useValue: new URL(`${environment.apiPath}/${msgraph.apiPath}`, base_url).toString()
        },
        container.service.ContainerService,
        {
          provide: container.BASE_PATH,
          useValue: new URL(`${environment.apiPath}/${container.apiPath}`, base_url).toString()
        },
        orgissuer.service.OrganisationIssuerService,
        {
          provide: orgissuer.BASE_PATH,
          useValue: new URL(`${environment.apiPath}/${orgissuer.apiPath}`, base_url).toString()
        },
        IssuableCredentials.service.IssuableCredentialsService,
        {
          provide: IssuableCredentials.BASE_PATH,
          useValue: new URL(`${environment.apiPath}/${IssuableCredentials.apiPath}`, base_url).toString()
        }
      ]
    };
  }
}
