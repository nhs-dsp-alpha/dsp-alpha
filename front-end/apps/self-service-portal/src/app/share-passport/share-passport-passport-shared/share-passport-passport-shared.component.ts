import { Component, Input, OnInit } from '@angular/core';
import { IParamsCard } from '@front-end/shared/ui';
import { organisations } from '@front-end/shared/services';

@Component({
  selector: 'self-service-share-passport-passport-shared',
  templateUrl: './share-passport-passport-shared.component.html',
  styleUrls: ['./share-passport-passport-shared.component.css']
})
export class SharePassportPassportSharedComponent implements OnInit {
  @Input()
  selectedOrganisation?: organisations.Organisation;

  passportSharedParams: IParamsCard = {};

  constructor() { }

  ngOnInit(): void {
    this.passportSharedParams = {
      heading: 'Passport shared', headingLevel: 1, descriptionHtml: `You shared your passport with ${this.selectedOrganisation?.name}`, clickable: false, classes: 'nhsuk-card--confirmation'
    };
  }

}
