import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { MicrosoftGraphService } from './microsoft-graph.service';
import { ApiMsGraphService } from './api';
import { ENV } from '../../../../env';

describe('MicrosoftGraphService', () => {
  let service: MicrosoftGraphService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ],
      providers: [
        MicrosoftGraphService,
        ApiMsGraphService,
        { provide: ENV, useValue: { }}
      ]
    });
    service = TestBed.inject(MicrosoftGraphService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
