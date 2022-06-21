import { Component } from '@angular/core';

import { IParamsFooter, IParamsHeader } from '@front-end/shared/ui';
import { AuthenticationService } from '@front-end/shared/authentication';

@Component({
  selector: 'self-service-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {

  public headerParams!: IParamsHeader;
  public footerParams!: IParamsFooter;

  private  _isAuthenticated = false;

  constructor(private auth: AuthenticationService){
    this.setParams(this.isAuthenticated);

    this.setFooterParams();

    this.auth.authenticationStatus.subscribe(isAuthenticated => {
      this._isAuthenticated = isAuthenticated;
      this.setParams(isAuthenticated);
    });
  }

  get isAuthenticated(): boolean {
    return this._isAuthenticated;
  }

  onLoginClicked() {
    this.login();
  }

  login() {
    this.auth.login();
  }

  onLogoutClicked() {
    this.logout();
  }

  logout() {
    this.auth.logout();
  }

  setParams(isAuthenticated: boolean = false) {
    this.headerParams = isAuthenticated ? {
      showNav: true,
      showSearch: false,
      service: {
        name: "Digital Staff Passport"
      },
      primaryLinks: [
        {
          url: ".",
          label: "Manage Notifications"
        },
        {
          url: '.',
          label: 'Settings'
        },
      ]
    } : {
      showNav: true,
      showSearch: false,
      service: {
        name: "Digital Staff Passport"
      },
      primaryLinks: [
      ]
    }
  }

  setFooterParams() {
    this.footerParams = {
      "links": [
        {
          "URL": "#",
          "label": "Home"
        },
        {
          "URL": "#",
          "label": "Credentials"
        },
        {
          "URL": "#",
          "label": "Organisations"
        },
        {
          "URL": "#",
          "label": "Profile"
        }
      ]
    }
  }
}
