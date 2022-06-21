import { Component, EventEmitter, Output } from '@angular/core';
import { IParamsCard } from '@front-end/shared/ui';

@Component({
  selector: 'self-service-self-attested-data-added',
  templateUrl: './self-attested-data-added.component.html',
  styleUrls: ['./self-attested-data-added.component.css']
})
export class SelfAttestedDataAddedComponent {
  passportSharedParams: IParamsCard = { heading: 'Emergency Contact Added', headingLevel: 1, descriptionHtml: `You added a new emergency contact to your profile`, clickable: false, classes: 'nhsuk-card--confirmation' };

  constructor() {
  }

}
