import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { ApiOrganisationsService } from './api';

import { OrganisationsService } from './organisations.service';

describe('OrganisationsService', () => {
  let service: OrganisationsService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ],
      providers: [
        OrganisationsService,
        ApiOrganisationsService
      ]
    });
    service = TestBed.inject(OrganisationsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
