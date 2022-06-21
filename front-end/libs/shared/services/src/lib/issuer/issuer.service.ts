import { Injectable } from '@angular/core';
import { firstValueFrom, share, map, BehaviorSubject } from 'rxjs';
import { AuthenticationService } from '@front-end/shared/authentication';
import { ApiIssuerService, ConnectionRequest } from './api';
import { Organisation, OrganisationsService } from '../organisations/organisations.service';

export { ConnectionRequest } from './api';

@Injectable()
export class IssuerService {
  private _connections = new Array<IConnection>();
  private _connections$ = new BehaviorSubject<IConnection[]>(this._connections);

  constructor(
    private service: ApiIssuerService,
    private organisationsService: OrganisationsService,
    private authentication: AuthenticationService) {
  }

  public connect(request: ConnectionRequest) {
    const userProfile = this.authentication.userProfile;

    request.sub.push({ key: 'givenName', value: userProfile?.first_name });
    request.sub.push({ key: 'surname', value: userProfile?.last_name });

    return firstValueFrom(this.service.connect('', request))
      .then(data => {
        this.notifyPending(request);
        return data;
      });
  }

  public get isAuthenticated(): boolean {
    return this.authentication.isAuthenticated;
  }

  public get connections$() {
    return this._connections$.pipe(share());
  }

  public get connectionsCount$() {
    return this.connections$.pipe(map((connections) => { return connections.length }));
  }

  public get hasConnections$() {
    return this.connectionsCount$.pipe(map((count) => { return count > 0 }));
  }

  public get completedConnections$() {
    return this.connections$.pipe(map(c => c.filter(v => !v.isPending)));
  }

  public get completedConnectionsCount$() {
    return this.completedConnections$.pipe(map((connections) => { return connections.length }));
  }

  public get hasCompletedConnections$() {
    return this.completedConnectionsCount$.pipe(map((count) => { return count > 0 }));
  }

  public get pendingConnections$() {
    return this.connections$.pipe(map(c => c.filter(v => v.isPending)));
  }

  public get pendingConnectionsCount$() {
    return this.pendingConnections$.pipe(map((connections) => { return connections.length }));
  }

  public get hasPendingConnections$() {
    return this.pendingConnectionsCount$.pipe(map((count) => { return count > 0 }));
  }

  private notifyPending(request: ConnectionRequest) {
    // *********************************
    // ********** placeholder **********
    // *********************************

    firstValueFrom(this.organisationsService.organisations$)
      .then(orgs => {
        const thisOrg = orgs.find(o => o.code == request.organisationCode);
        const pending = { request, organisationName: thisOrg?.name, date: new Date(), isPending: true } as IConnection;
        const arr = this._connections.concat([pending]);
        this._connections = arr;
        this._connections$.next(this._connections);
      });
  }
}

export interface IConnection {
  request?: ConnectionRequest,
  organisationName: string,
  date: Date,
  isPending?: boolean
}