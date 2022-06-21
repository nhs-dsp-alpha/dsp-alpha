import { TestBed } from '@angular/core/testing';

import { IssueVerifyService } from './issue-verify.service';

describe('IssueVerifyService', () => {
  let service: IssueVerifyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(IssueVerifyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
