import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, share } from 'rxjs';
import { ApiOrganisationsService, Organisation } from './api';

export { Organisation } from './api';

@Injectable()
export class OrganisationsService {
  private _organisations$ = new BehaviorSubject<Organisation[]>([]);

  constructor(private service: ApiOrganisationsService) {
  }

  public get organisations$(): Observable<Organisation[]> {
    return this._organisations$.pipe(share());
  }

  public getList() : Observable<Organisation[]>{
    this.service.list()
      .subscribe(data => this._organisations$.next(data));
    return this.organisations$;
  }
}
