import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

export const APP_ROUTES: Routes = [
  {
    path: '',
    component: HomeComponent,
    pathMatch: 'full'
  }
  //   {
  //     path: 'notifications',
  //     loadChildren: () => import('profileFrontEnd/Module').then(m => m.RemoteEntryModule)
  //   },
  //   {
  //     path: 'terms',
  //     loadChildren: () => import('bmi/Module').then(m => m.RemoteEntryModule)
  // }
];

