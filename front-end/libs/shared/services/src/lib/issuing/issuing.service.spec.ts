import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { IssuingService } from './issuing.service';
import { ENV } from '../../../../env';
import { ApiIssuingService } from './api';

describe('IssuingService', () => {
  let service: IssuingService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ],
      providers: [
        IssuingService,
        ApiIssuingService,
        { provide: ENV, useValue: { }}
      ]

    });
    service = TestBed.inject(IssuingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
