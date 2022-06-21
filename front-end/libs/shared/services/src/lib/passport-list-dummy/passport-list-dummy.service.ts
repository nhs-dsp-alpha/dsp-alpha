import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable()
export class PassportListDummyService {

  tableRows: passport[];

  constructor() {
    this.tableRows = [
      {
        displayName: 'Kasper Schmidt',
        id: 1,
        receivedAt: new Date(),
        status: 'Needing information'
      }
    ]
  }

  public getTableRows(): Observable<passport[]> {
    return of(this.tableRows);
  }
}

export interface passport {
  displayName?: string;
  id?: number;
  receivedAt?: Date;
  status: string;
}