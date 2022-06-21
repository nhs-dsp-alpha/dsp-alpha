import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharePassportRoutingModule } from './share-passport-routing.module';
import { SharePassportComponent } from './share-passport.component';

import { SharedUiModule } from '@front-end/shared/ui';
import { SharePassportFindOrganisationComponent } from './share-passport-find-organisation/share-passport-find-organisation.component';
import { SharePassportSelectOrganisationComponent } from './share-passport-select-organisation/share-passport-select-organisation.component';
import { SharePassportAddDobComponent } from './share-passport-add-dob/share-passport-add-dob.component';
import { SharePassportShareCredentialsComponent } from './share-passport-share-credentials/share-passport-share-credentials.component';
import { SharePassportVerifyCredentialsComponent } from './share-passport-verify-credentials/share-passport-verify-credentials.component';

import { FormsModule } from '@angular/forms';
import { SharePassportFormComponent } from './share-passport-form/share-passport-form.component';
import { SharePassportPassportSharedComponent } from './share-passport-passport-shared/share-passport-passport-shared.component';

@NgModule({
  declarations: [
    SharePassportComponent,
    SharePassportFindOrganisationComponent,
    SharePassportSelectOrganisationComponent,
    SharePassportAddDobComponent,
    SharePassportShareCredentialsComponent,
    SharePassportVerifyCredentialsComponent,
    SharePassportFormComponent,
    SharePassportPassportSharedComponent
  ],
  imports: [
    CommonModule,
    SharePassportRoutingModule,
    SharedUiModule,
    FormsModule
  ]
})
export class SharePassportModule { }
