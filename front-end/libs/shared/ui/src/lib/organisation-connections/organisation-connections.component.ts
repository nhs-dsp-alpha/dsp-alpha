import { Component } from '@angular/core';
import { issuer } from '@front-end/shared/services';

@Component({
  selector: 'front-end-organisation-connections',
  templateUrl: './organisation-connections.component.html',
  styleUrls: ['./organisation-connections.component.scss']
})
export class OrganisationConnectionsComponent {

  constructor(
    private service: issuer.IssuerService) { }

  public get isAuthenticated(): boolean {
    return this.service.isAuthenticated;
  }
  
  public get connections$() {
    return this.service.connections$;
  }
  
  public get hasConnections$() {
    return this.service.hasConnections$;
  }

  public get connectionsCount$() {
    return this.service.connectionsCount$;
  }

  public get completedConnectionsCount$() {
    return this.service.completedConnectionsCount$;
  }

  public get pendingConnectionsCount$() {
    return this.service.pendingConnectionsCount$;
  }

  public get hasPendingConnections$() {
    return this.service.hasPendingConnections$;
  }

  public get pendingConnections$() {
    return this.service.pendingConnections$;
  }
}
