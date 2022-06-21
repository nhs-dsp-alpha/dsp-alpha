import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';

@Injectable()
export class ConfigurationService {
  private _promise?: Promise<Configuration | undefined>;

  constructor(private http: HttpClient) {
  }

  public getConfiguration(): Promise<Configuration | undefined> {
    console.log('ConfigurationService:checkConfig');

    if (!this._promise) {
      const req = this.http.get<Configuration>('config');
      this._promise = firstValueFrom(req)
        .then((config: Configuration) => {
          return config;
        }).catch(error => {
          console.error(error);
          return undefined;
        });
    }

    return this._promise;
  }
}

export interface Configuration {
  organisationName: string;
  organisationCode: string;
}
