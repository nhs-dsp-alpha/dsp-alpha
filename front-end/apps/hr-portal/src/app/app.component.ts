import { Component, ElementRef } from '@angular/core';

import { IParamsFooter, IParamsHeader } from '@front-end/shared/ui';
import { AuthenticationService } from '@front-end/shared/authentication';
import { HomeComponent } from './home/home.component';
import { configuration } from '@front-end/shared/services';
import { DesktopLandingComponent } from './desktop-landing/desktop-landing.component';

@Component({
  selector: 'hr-portal-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {

  public headerParams!: IParamsHeader;
  public footerParams!: IParamsFooter;

  private _isAuthenticated = false;
  config: configuration.Configuration | undefined;

  setOrganisation = false;

  constructor(private auth: AuthenticationService, private configurationService: configuration.ConfigurationService) {
    this.setParams(this.isAuthenticated);

    this.setFooterParams();

    this.auth.authenticationStatus.subscribe(isAuthenticated => {
      this._isAuthenticated = isAuthenticated;
      this.configurationService.getConfiguration().then(org => {
        this.config = org;
        this.setParams(isAuthenticated);
      })
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

  setParams(isAuthenticated: boolean) {
    this.headerParams = isAuthenticated ? {
      showNav: true,
      showSearch: false,
      service: {
        name: "Digital Staff Passport"
      },
      primaryLinks: [
        {
          url: ".",
          label: "Issue information to passports"
        },
        {
          url: '.',
          label: 'Accept shared passports'
        },
        {
          url: '.',
          label: 'View all passports'
        },
        {
          url: '.',
          label: 'Manage users'
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


    if (this.config?.organisationName && this.setOrganisation) {
      this.headerParams.organisation =
      {
        name: "Digital Staff Passport",
        descriptor: this.config?.organisationName,
        logoURL: "",
        split: ""
      }
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

  // Keeps the organisation hidden from the user until an organisation has been selected
  childSelectedOrganisation(componetRef: HomeComponent) {
    if (!(componetRef instanceof HomeComponent)) {
      return;
    }

    const child: HomeComponent = componetRef;

    // This sets the organisation in the header, after an org has been selected. Api Management will be redirecting to the correct back end to get the correct config.
    child.hideOrganisation.subscribe(hideOrganisation => {
      if (!hideOrganisation) {
        this.setOrganisation = true;
        this.setParams(this.isAuthenticated);
      }
      else {
        this.setOrganisation = false;
        this.setParams(this.isAuthenticated);
      }
    });
  }

  // Displays the organisation in the header when on desktop landing page
  desktopLandingPage(componetRef: DesktopLandingComponent) {
    if (!(componetRef instanceof DesktopLandingComponent)) {
      return;
    }

    const child: DesktopLandingComponent = componetRef;
    child.displayOrganisation.subscribe(() => {
      this.setOrganisation = true;
      this.setParams(this.isAuthenticated);
    })

  }
}
