import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NhsFrontEndModule } from './nhs-front-end/nhs-front-end.module';
import { SignInComponent } from './sign-in/sign-in.component';
import { IssueVerifyComponent } from './issue-verify/issue-verify.component';
import { OrganisationConnectionsComponent } from './organisation-connections/organisation-connections.component';
import { ProfileComponent } from './profile/profile.component';
import { PassportActivityComponent } from './passport-activity/passport-activity.component';
import { ProfileCompletionComponent } from './profile-completion/profile-completion.component';
import { SelectWalletComponent } from './select-wallet/select-wallet.component';
import { OrganisationsComponent } from './organisations/organisations.component';
import { ProfileSummaryComponent } from './profile-summary/profile-summary.component';
import { RouterModule } from '@angular/router';
import { SharePassportComponent } from './share-passport/share-passport.component';
import { FindOrganisationComponent } from './find-organisation/find-organisation.component';
import { SelectOrganisationComponent } from './select-organisation/select-organisation.component';
import { FormsModule } from '@angular/forms';
import { AddDobComponent } from './add-dob/add-dob.component';

@NgModule({
  imports: [
    CommonModule,
    NhsFrontEndModule,
    RouterModule,
    FormsModule
  ],
  declarations: [
    SignInComponent,
    IssueVerifyComponent,
    OrganisationConnectionsComponent,
    ProfileComponent,
    PassportActivityComponent,
    ProfileCompletionComponent,
    SelectWalletComponent,
    OrganisationsComponent,
    ProfileSummaryComponent,
    SharePassportComponent,
    FindOrganisationComponent,
    SelectOrganisationComponent,
    AddDobComponent
  ],
  exports: [
    NhsFrontEndModule,
    SignInComponent,
    IssueVerifyComponent,
    OrganisationConnectionsComponent,
    ProfileComponent,
    PassportActivityComponent,
    ProfileCompletionComponent,
    SelectWalletComponent,
    OrganisationsComponent,
    ProfileSummaryComponent,
    SharePassportComponent,
    FindOrganisationComponent,
    SelectOrganisationComponent,
    AddDobComponent
  ]
})
export class SharedUiModule { }
