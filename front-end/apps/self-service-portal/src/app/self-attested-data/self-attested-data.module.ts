import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddEmergencyContactDetailsComponent } from './add-emergency-contact-details/add-emergency-contact-details.component';
import { SelfAttestedDataComponent } from './self-attested-data.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SelfAttestedDataRoutingModule } from './self-attested-data-routing.module';
import { Routes, RouterModule } from '@angular/router';
import { SharedUiModule } from '@front-end/shared/ui';
import { SelfAttestedDataAddedComponent } from './self-attested-data-added/self-attested-data-added.component';

const routes: Routes = [
  {
    path: '', component: SelfAttestedDataComponent, children: [

    ]
  }
];

@NgModule({
  declarations: [
    AddEmergencyContactDetailsComponent,
    SelfAttestedDataComponent,
    SelfAttestedDataAddedComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    SelfAttestedDataRoutingModule,
    RouterModule.forChild(routes),
    SharedUiModule
  ]
})
export class SelfAttestedDataModule { }
