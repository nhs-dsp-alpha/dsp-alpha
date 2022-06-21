import { TestBed } from '@angular/core/testing';

import { PassportListDummyService, TableRow } from './passport-list-dummy.service';

describe('PassportListDummyService', () => {
  let service: PassportListDummyService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
      ],
      providers: [
        PassportListDummyService
      ]
    });
    service = TestBed.inject(PassportListDummyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should return config', () => {
    const tableRows: TableRow[] = [
      { text: "Kasper Schmidt" },
      { text: "7 Aug 2022" },
      { text: "Needing information" },
      { text: "Issue information", clickable: true, tag: "1", format: "clickable" },
    ];

    service.getTableRows().subscribe((result) => {
      expect(result).toEqual(tableRows);
    });
  });
});