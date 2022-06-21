import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { SharedUiModule } from '@front-end/shared/ui';

import { ViewPassportsIssueComponent } from './view-passports-issue/view-passports-issue.component';
import { RouterModule } from '@angular/router';
import { APP_ROUTES } from './issue-passports-routing.module';
import { ViewPassportComponent } from './view-passport/view-passport.component';


@NgModule({
  declarations: [
    ViewPassportsIssueComponent,
    ViewPassportComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(APP_ROUTES),
    SharedUiModule,
    FormsModule
  ]
})
export class IssuePassportsModule { }
