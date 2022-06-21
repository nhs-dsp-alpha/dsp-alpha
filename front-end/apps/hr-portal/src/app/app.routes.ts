import { Routes } from '@angular/router';
import { ConnectionRequestsComponent } from './connection-requests/connection-requests.component';
import { DesktopLandingComponent } from './desktop-landing/desktop-landing.component';
import { HomeComponent } from './home/home.component';

export const APP_ROUTES: Routes = [
  {
    path: '',
    component: HomeComponent,
    pathMatch: 'full'
  },
  {
    path: 'desktop',
    component: DesktopLandingComponent,
    pathMatch: 'full'
  },
  {
    path: 'requests',
    component: ConnectionRequestsComponent,
    pathMatch: 'full'
  },
  {
    path: 'add-staff-choice',
    loadChildren: () => import('./add-staff/add-staff.module').then(m => m.AddStaffModule)
  },
  {
    path: 'view-passports-issue',
    loadChildren: () => import('./issue-passports/issue-passports.module').then(m => m.IssuePassportsModule)
  }
  //   {
  //     path: 'terms',
  //     loadChildren: () => import('bmi/Module').then(m => m.RemoteEntryModule)
  // }
];

