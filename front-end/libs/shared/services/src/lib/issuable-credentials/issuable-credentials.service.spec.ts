import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { AuthenticationService } from '@front-end/shared/authentication';
import { OrganisationsService } from '../organisations/organisations.service';
import { ApiOrganisationsService } from '../organisations/api';
import { ApiIssuableCredentialsService } from './api';

import { IssuableCredentialsService } from './issuable-credentials.service';
import { ENV } from '../../../../env';

describe('IssuerService', () => {
  let service: IssuableCredentialsService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ],
      providers: [
        IssuableCredentialsService,
        ApiIssuableCredentialsService,
        OrganisationsService,
        ApiOrganisationsService,
        AuthenticationService,
        { provide: ENV, useValue: {} }
      ]
    });
    service = TestBed.inject(IssuableCredentialsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
