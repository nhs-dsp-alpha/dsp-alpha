import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { HeaderComponent } from './navigation/header/header.component';
import { LogoComponent } from './logo/logo.component';
import { FooterComponent } from './navigation/footer/footer.component';
import { BreadcrumbsComponent } from './navigation/breadcrumbs/breadcrumbs.component';
import { ActionLinkComponent } from './navigation/action-link/action-link.component';
import { BackLinkComponent } from './navigation/back-link/back-link.component';
import { CardComponent } from './navigation/card/card.component';
import { ContentsListComponent } from './navigation/contents-list/contents-list.component';
import { PaginationComponent } from './navigation/pagination/pagination.component';
import { RouterModule } from '@angular/router';
import { CareCardComponent } from './presentation/care-card/care-card.component';
import { DetailsComponent } from './presentation/details/details.component';
import { DoAndDontListComponent } from './presentation/do-and-dont-list/do-and-dont-list.component';
import { ExpanderComponent } from './presentation/expander/expander.component';
import { ImageComponent } from './presentation/image/image.component';
import { InsetTextComponent } from './presentation/inset-text/inset-text.component';
import { SummaryListComponent } from './presentation/summary-list/summary-list.component';
import { TableComponent } from './presentation/table/table.component';
import { TagComponent } from './presentation/tag/tag.component';
import { WarningCalloutComponent } from './presentation/warning-callout/warning-callout.component';
import { SkipLinkComponent } from './navigation/skip-link/skip-link.component';
import { ButtonComponent, CheckBoxComponent, DateInputComponent, ErrorMessageComponent, ErrorSummaryComponent, HintTextComponent, RadioComponent, SelectComponent, TextInputComponent } from './forms';

@NgModule({
  declarations: [
    HeaderComponent,
    LogoComponent,
    FooterComponent,
    BreadcrumbsComponent,
    ActionLinkComponent,
    BackLinkComponent,
    CardComponent,
    ContentsListComponent,
    PaginationComponent,
    CareCardComponent,
    DetailsComponent,
    DoAndDontListComponent,
    ExpanderComponent,
    ImageComponent,
    InsetTextComponent,
    SummaryListComponent,
    TableComponent,
    TagComponent,
    WarningCalloutComponent,
    SkipLinkComponent,
    ButtonComponent,
    HintTextComponent,
    ErrorSummaryComponent,
    ErrorMessageComponent,
    RadioComponent,
    CheckBoxComponent,
    SelectComponent,
    DateInputComponent,
    TextInputComponent
  ],
  imports: [
    ReactiveFormsModule,
    CommonModule,
    RouterModule 
  ],
  exports: [
    HeaderComponent,
    LogoComponent,
    FooterComponent,
    BreadcrumbsComponent,
    ActionLinkComponent,
    BackLinkComponent,
    CardComponent,
    ContentsListComponent,
    PaginationComponent,
    CareCardComponent,
    DetailsComponent,
    DoAndDontListComponent,
    ExpanderComponent,
    ImageComponent,
    InsetTextComponent,
    SummaryListComponent,
    TableComponent,
    TagComponent,
    WarningCalloutComponent,
    SkipLinkComponent,
    ButtonComponent,
    HintTextComponent,
    ErrorSummaryComponent,
    ErrorMessageComponent,
    RadioComponent,
    CheckBoxComponent,
    SelectComponent,
    DateInputComponent,
    TextInputComponent,
    // ReactiveFormsModule
  ]
})
export class NhsFrontEndModule { }
