import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiModule, ClientRequest, ClientResponse, CredentialRequest, ApiOrganisationIssuerService, IssuableCredential } from './api';

export { CredentialRequest, IssuableCredential } from './api';

@Injectable({
  providedIn: 'root'
})
export class OrganisationIssuerService {

  constructor(private service: ApiOrganisationIssuerService) { }

  public GetCredentialResponse(body: CredentialRequest, observe?: 'body', reportProgress?: boolean): Observable<IssuableCredential> {
    const result$ = this.service.getCredentialResponse(body);
    return result$;
  }
  public GetClientResponse(body: ClientRequest, observe?: 'body', reportProgress?: boolean): Observable<ClientResponse> {
    const result$ = this.service.getClientResponse(body);
    return result$;
  }


}
