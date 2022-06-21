import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { AddOrganisationRoutingModule } from './add-organisation-routing.module';
import { AddOrganisationComponent } from './add-organisation.component';
import { FindOrganisationComponent } from './find-organisation/find-organisation.component';
import { SelectOrganisationComponent } from './select-organisation/select-organisation.component';
import { AddPhotoComponent } from './add-photo/add-photo.component';
import { AddEmpidComponent } from './add-empid/add-empid.component';
import { AddDobComponent } from './add-dob/add-dob.component';
import { AddOrganisationFormComponent } from './add-organisation-form/add-organisation-form.component';

import { FormsModule } from '@angular/forms';
import { SharedUiModule } from '@front-end/shared/ui';
import { ProfilePictureModule } from '../profile-picture/profile-picture.module';

const routes: Routes = [
  {
    path: '', component: AddOrganisationComponent, children: [

    ]
  }
];

@NgModule({
  declarations: [
    AddOrganisationComponent,
    FindOrganisationComponent,
    SelectOrganisationComponent,
    AddPhotoComponent,
    AddEmpidComponent,
    AddDobComponent,
    AddOrganisationFormComponent
  ],
  imports: [
    CommonModule,
    SharedUiModule,
    ProfilePictureModule,
    FormsModule,
    AddOrganisationRoutingModule,
    RouterModule.forChild(routes)
  ]
})
export class AddOrganisationModule { }
