import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { ContainerService } from './container.service';
import { ENV } from '../../../../env';
import { ApiContainerService } from './api';

describe('ContainerService', () => {
  let service: ContainerService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ],
      providers: [
        ContainerService,
        ApiContainerService,
        { provide: ENV, useValue: { }}
      ]
    });
    service = TestBed.inject(ContainerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
