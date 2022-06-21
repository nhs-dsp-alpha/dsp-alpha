import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SharePassportComponent } from './share-passport.component';

const routes: Routes = [{ path: '', component: SharePassportComponent }];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SharePassportRoutingModule { }
