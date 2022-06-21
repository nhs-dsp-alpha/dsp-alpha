import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { ConfigurationService, Configuration } from './configuration.service';

describe('ConfigurationService', () => {
  let service: ConfigurationService;
  let httpController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ],
      providers: [
        ConfigurationService
      ]
    });
    service = TestBed.inject(ConfigurationService);
    httpController = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should return config', () => {
    const config: Configuration = {
      organisationName: 'org',
      organisationCode: 'orgCode'
    }

    service.getConfiguration().then((result) => {
      expect(result).toEqual(config);
    });

    const req = httpController.expectOne({
      method: 'GET',
    });

    req.flush(config);
  });
});
