import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { IParamsBackLink, IParamsCard } from '@front-end/shared/ui';

@Component({
  templateUrl: './desktop-landing.component.html',
  styleUrls: ['./desktop-landing.component.scss'],
})
export class DesktopLandingComponent implements OnInit {
  @Output()
  public displayOrganisation = new EventEmitter<boolean>();

  backlink: IParamsBackLink = { href: undefined, routerLink: '/', text: 'Back', clickable: true };

  constructor(private router: Router) {
    console.log();
  }

  betaHubArrow = `<div class="beta-hub-arrow" style="display: inline; position: absolute; right: 24px;">
  <svg class="nhsuk-icon beta-icon__chevron-right-circle" style="fill: #005eb8" xmlns="http://www.w3.org/2000/svg"
      width="27" height="27" aria-hidden="true">
      <circle cx="13.333" cy="13.333" r="13.333" fill=""></circle>
      <g data-name="Group 1" fill="none" stroke="#fff" stroke-linecap="round"
          stroke-miterlimit="10" stroke-width="2.667">
          <path d="M15.438 13l-3.771 3.771"></path>
          <path data-name="Path" d="M11.667 9.229L15.438 13"></path>
      </g>
  </svg>
</div>`

  issueInformation: IParamsCard = { headingHtml: `<h3><a style="text-decoration: underline; padding-right: 75px; display: inline;">Issue information to passports</a>${this.betaHubArrow}</h3>`, description: 'Confirm identity, and issue employment and training information', clickable: true };
  acceptSharedPassports: IParamsCard = { headingHtml: `<h3><a style="text-decoration: underline; padding-right: 75px; display: inline;">Accept shared passports</a>${this.betaHubArrow}</h3>`, description: 'Check and accept digital staff passports shared with you.', clickable: true };
  issueDigitalStaffPassports: IParamsCard = { headingHtml: `<h3><a style="text-decoration: underline; padding-right: 75px; display: inline;">Issue digital staff passports</a>${this.betaHubArrow}</h3>`, description: 'Manually issue passports for people currently working in your organisation.', clickable: true };

  ngOnInit() {
    // Feeds back to app component to change header params to display organisation
    this.displayOrganisation.emit(true);
  }

  onSharedPassportsClicked() {
    this.router.navigateByUrl('/requests');
  }

  onIssueDigitalStaffPassportsClicked() {
    this.router.navigateByUrl('/add-staff-choice');
  }
  onIssueInformationToPassportsClicked() {
    this.router.navigateByUrl('/view-passports-issue');
  }
} 
