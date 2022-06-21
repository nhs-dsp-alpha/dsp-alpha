import { Component } from '@angular/core';
import { AuthenticationService } from '@front-end/shared/authentication';

@Component({
  selector: 'front-end-share-passport',
  templateUrl: './share-passport.component.html',
  styleUrls: ['./share-passport.component.css']
})
export class SharePassportComponent {

  constructor(private authenticationService: AuthenticationService) { }

  public get isAuthenticated(): boolean {
    return this.authenticationService.isAuthenticated;
  }

}
