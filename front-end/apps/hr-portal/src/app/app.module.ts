import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { SharedUiModule } from '@front-end/shared/ui';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { APP_ROUTES } from './app.routes';
import { AppInitService } from './services/app-init.service';

import { SharedAuthenticationModule } from '@front-end/shared/authentication';
import { SharedCredentialsModule } from '@front-end/shared/credentials';
import { environment } from '../environments/environment';
import { SelectOrganisationComponent } from './select-organisation/select-organisation.component';
import { DesktopLandingComponent } from './desktop-landing/desktop-landing.component';
import { SharedServicesModule } from '@front-end/shared/services';
import { ConnectionRequestsComponent } from './connection-requests/connection-requests.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SelectOrganisationComponent,
    DesktopLandingComponent,
    ConnectionRequestsComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(APP_ROUTES),
    SharedCredentialsModule.forRoot(environment),
    SharedAuthenticationModule.forRoot(environment),
    SharedServicesModule.forRoot(environment),
    HttpClientModule,
    SharedUiModule,
    FormsModule,
  ],
  providers: [
    AppInitService,
    {
      provide: APP_INITIALIZER,
      useFactory: (appInitService: AppInitService) => {
        return (): Promise<unknown> => {
          return appInitService.load();
        };
      },
      deps: [AppInitService],
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
