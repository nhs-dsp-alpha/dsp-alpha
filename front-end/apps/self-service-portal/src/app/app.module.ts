import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { SharedUiModule } from '@front-end/shared/ui';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
// import { APP_ROUTES } from './app.routes';
import { AppInitService } from './services/app-init.service';

import { SharedAuthenticationModule } from '@front-end/shared/authentication';
import { SharedCredentialsModule } from '@front-end/shared/credentials';
import { SharedServicesModule } from '@front-end/shared/services';
import { environment } from "../environments/environment";
import { AddProfilePictureComponent } from './profile-picture/add-profile-picture/add-profile-picture.component';
import { AddSelfAttestedDataComponent } from './add-self-attested-data/add-self-attested-data.component';
import { AcceptCredentialComponent } from './accept-credential/accept-credential.component';

export const APP_ROUTES: Routes = [
  {
    path: '',
    component: HomeComponent,
    pathMatch: 'full'
  },
  {
    path: 'add-photo',
    component: AddProfilePictureComponent,
    pathMatch: 'full'
  },
  { path: 'addorganisation', loadChildren: () => import('./add-organisation/add-organisation.module').then(m => m.AddOrganisationModule) },
  { path: 'sharepassport', loadChildren: () => import('./share-passport/share-passport.module').then(m => m.SharePassportModule) },
  { path: 'selfattesteddata', loadChildren: () => import('./self-attested-data/self-attested-data.module').then(m => m.SelfAttestedDataModule) },
];


@NgModule({
  declarations: [AppComponent, HomeComponent, AddSelfAttestedDataComponent, AcceptCredentialComponent],
  imports: [
    BrowserModule,
    RouterModule.forRoot(APP_ROUTES),
    SharedCredentialsModule.forRoot(environment),
    SharedAuthenticationModule.forRoot(environment),
    SharedServicesModule.forRoot(environment),
    HttpClientModule,
    SharedUiModule
  ],
  providers: [
    AppInitService,
    {
      provide: APP_INITIALIZER,
      useFactory: (appInitService: AppInitService) => {
        return (): Promise<unknown> => {
          return appInitService.load();
        }
      },
      deps: [AppInitService],
      multi: true
    },

  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
