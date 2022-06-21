import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { share, map, BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrganisationConnectionsService {
  private _connections$ = new BehaviorSubject<IConnection[]>([]);

  constructor(private http: HttpClient) {
    // this._connections$.next([{isPending: false}]);
  }

  public get connections$() {
    return this._connections$.pipe(share());
  }

  public get hasConnections$() {
    return this.connections$.pipe(map((connections) => {return connections.length > 0}));
  }

  public get pendingConnections$() {
    return this.connections$.pipe(map(c => c.filter(v => v.isPending)));
  }

  public get hasPendingConnections$() {
    return this.pendingConnections$.pipe(map((connections) => {return connections.length > 0}));
  }
}

interface IConnection {
  isPending?: boolean
}