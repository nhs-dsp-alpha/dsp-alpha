import { Component, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { IParamsBackLink } from '@front-end/shared/ui';

@Component({
  selector: 'self-service-add-emergency-contact-details',
  templateUrl: './add-emergency-contact-details.component.html',
  styleUrls: ['./add-emergency-contact-details.component.css']
})
export class AddEmergencyContactDetailsComponent {
  @Output()
  public continue = new EventEmitter<boolean>();

  backlink: IParamsBackLink = { href: undefined, routerLink: '/', text: 'Back', clickable: true };

  emergencyContactDetails = new FormGroup({
    EmergContactTitle: new FormControl(''),
    EmergContactFirstName: new FormControl(''),
    EmergContactLastName: new FormControl(''),
    EmergContactPreferredTelephoneNumber: new FormControl(''),
    EmergContactSecondaryTelephoneNumber: new FormControl(''),
    EmergContactRelationship: new FormControl('')
  });

  constructor() {
  }

  onEmergencyContactDetailsSubmit() {
    console.log(this.emergencyContactDetails.value);
    this.continue.emit(true);
  }



}
