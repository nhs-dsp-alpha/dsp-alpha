import { Injectable } from '@angular/core';
import { BehaviorSubject, firstValueFrom, Observable, share } from 'rxjs';
import { ApiIssuingService, ConnectionRequest, ConnectionRequestStatus, Credential, CredentialStatus } from './api';

export { ConnectionRequest, ConnectionRequestStatus, Credential, CredentialStatus } from './api';

@Injectable()
export class IssuingService {
  private _requests$ = new BehaviorSubject<ConnectionRequest[]>([]);
  private _accepted$ = new BehaviorSubject<ConnectionRequest[]>([]);

  private _changedRequests = new Array<ConnectionRequest>();

  constructor(private service: ApiIssuingService) {
  }

  public get requests$(): Observable<ConnectionRequest[]> {
    return this._requests$.pipe(share());
  }

  public get accepted$(): Observable<ConnectionRequest[]> {
    return this._accepted$.pipe(share());
  }

  public get changedRequests(): ConnectionRequest[] {
    return this._changedRequests;
  }

  public getPending(): Observable<ConnectionRequest[]> {
    this.service.getPending("", "")
      .subscribe(data => this._requests$.next(data));
    return this.requests$;
  }

  public getAccepted(): Observable<ConnectionRequest[]> {
    this.service.getAccepted("", "")
      .subscribe(data => this._accepted$.next(data));
    return this.accepted$;
  }

  public updateStatus(id: number, status: ConnectionRequestStatus) {
    return firstValueFrom(this.service.updateStatus("", "", id, { status}))
    .then(value => {
      firstValueFrom(this.getPending()).then(() => this._changedRequests[value.id] = value);
      return value;
    });
 }
}
