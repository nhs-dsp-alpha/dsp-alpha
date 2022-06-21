import { Routes } from '@angular/router';
import { ViewPassportComponent } from './view-passport/view-passport.component';
import { ViewPassportsIssueComponent } from './view-passports-issue/view-passports-issue.component';

export const APP_ROUTES: Routes = [
  {
    path: '',
    component: ViewPassportsIssueComponent,
    pathMatch: 'full'
  },
  {
    path: 'view-passport/:id',
    component: ViewPassportComponent,
    pathMatch: 'full'
  }
];