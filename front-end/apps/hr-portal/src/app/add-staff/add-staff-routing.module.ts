import { Routes } from '@angular/router';
import { AddStaffChoiceComponent } from './add-staff-choice/add-staff-choice.component';

export const APP_ROUTES: Routes = [
  {
    path: '',
    component: AddStaffChoiceComponent,
    pathMatch: 'full'
  }
];