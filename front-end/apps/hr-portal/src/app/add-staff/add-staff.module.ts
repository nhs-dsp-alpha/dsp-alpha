import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AddStaffChoiceComponent } from './add-staff-choice/add-staff-choice.component';
import { RouterModule } from '@angular/router';
import { APP_ROUTES } from './add-staff-routing.module';


@NgModule({
  declarations: [
    AddStaffChoiceComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(APP_ROUTES),
  ]
})
export class AddStaffModule { }
