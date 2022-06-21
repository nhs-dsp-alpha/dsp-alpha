import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SelfAttestedDataComponent } from './self-attested-data.component';

const routes: Routes = [{ path: '', component: SelfAttestedDataComponent }];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class SelfAttestedDataRoutingModule { }
