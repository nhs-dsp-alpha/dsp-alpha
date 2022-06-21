import { Injectable } from '@angular/core';
import { AuthenticationService } from '@front-end/shared/authentication';

@Injectable({
  providedIn: 'root'
})
export class AppInitService {

  constructor(private authService: AuthenticationService) { }

  public load(): Promise<unknown[]> {
    console.log('AppInitService:load:Start')
    return Promise.all([
      this.authService.checkStatus()
    ]);
  }
}
