import { TestBed } from '@angular/core/testing';

import { OrganisationIssuerService } from './organisation-issuer.service';

describe('OrganisationIssuerService', () => {
  let service: OrganisationIssuerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OrganisationIssuerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
