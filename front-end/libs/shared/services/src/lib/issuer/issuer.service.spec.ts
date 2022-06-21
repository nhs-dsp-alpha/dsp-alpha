import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { AuthenticationService } from '@front-end/shared/authentication';
import { OrganisationsService } from '../organisations/organisations.service';
import { ApiOrganisationsService } from '../organisations/api';
import { ApiIssuerService } from './api';

import { IssuerService } from './issuer.service';
import { ENV } from '../../../../env';

describe('IssuerService', () => {
  let service: IssuerService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ],
      providers: [
        IssuerService,
        ApiIssuerService,
        OrganisationsService,
        ApiOrganisationsService,
        AuthenticationService,
        { provide: ENV, useValue: { }}
      ]
    });
    service = TestBed.inject(IssuerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
