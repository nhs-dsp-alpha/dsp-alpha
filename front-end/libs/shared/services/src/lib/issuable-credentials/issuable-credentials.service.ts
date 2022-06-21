import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiIssuableCredentialsService, IssuableRequest } from './api'

export { IssuableRequest, MessageType } from './api';

@Injectable({
  providedIn: 'root'
})
export class IssuableCredentialsService {

  constructor(private service: ApiIssuableCredentialsService) { }

  public requestPost(body: IssuableRequest, observe?: 'body', reportProgress?: boolean): Observable<any> {
    const result$ = this.service.requestPost(body, "", "", observe, reportProgress);
    return result$;
  }
}
