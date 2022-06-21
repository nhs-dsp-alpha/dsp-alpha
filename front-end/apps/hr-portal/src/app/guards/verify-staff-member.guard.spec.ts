import { TestBed } from '@angular/core/testing';

import { VerifyStaffMemberGuard } from './verify-staff-member.guard';

describe('VerifyStaffMemberGuard', () => {
  let guard: VerifyStaffMemberGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(VerifyStaffMemberGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
