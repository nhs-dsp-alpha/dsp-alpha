import { TestBed } from '@angular/core/testing';

import { OrganisationConnectionsService } from './organisation-connections.service';

describe('OrganisationConnectionsService', () => {
  let service: OrganisationConnectionsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OrganisationConnectionsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
