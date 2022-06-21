import { TestBed } from '@angular/core/testing';

import { NhsUserService } from './nhs-user.service';

describe('NhsUserService', () => {
  let service: NhsUserService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NhsUserService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
