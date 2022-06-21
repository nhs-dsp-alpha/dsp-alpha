import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { DetailsComponent } from '../details/details.component';

@Component({
  selector: 'nhs-expander',
  templateUrl: '../details/details.component.html',
  styleUrls: ['../details/details.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ExpanderComponent extends DetailsComponent {

  constructor(sanitizer: DomSanitizer) {
    super(sanitizer);

    this.isExpander = true;
   }
}
