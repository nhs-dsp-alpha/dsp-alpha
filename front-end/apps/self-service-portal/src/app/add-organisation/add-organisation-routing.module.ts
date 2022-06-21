import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddOrganisationComponent } from './add-organisation.component';

const routes: Routes = [{ path: '', component: AddOrganisationComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AddOrganisationRoutingModule { }
