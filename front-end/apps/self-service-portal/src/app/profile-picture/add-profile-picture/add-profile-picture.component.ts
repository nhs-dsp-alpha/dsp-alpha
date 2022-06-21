import { Component } from '@angular/core';
import { IParamsBackLink } from '@front-end/shared/ui';
import { Router } from '@angular/router';

@Component({
  selector: 'self-service-add-profile-picture',
  templateUrl: './add-profile-picture.component.html',
  styleUrls: ['./add-profile-picture.component.scss'],
})
export class AddProfilePictureComponent {
  landingAddPhoto = true;
  heading = "Add a photo";
  displayPhotoFlow = false;

  cancelLink: IParamsBackLink = { href: undefined, routerLink: '..', text: 'Back', clickable: false };
  backlink: IParamsBackLink = { href: undefined, routerLink: '#', text: 'Back', clickable: true };

  constructor(private router: Router) {

  }

  startAddPhoto() {
    // Take user to upload or take photo component
    this.displayPhotoFlow = true;
    this.landingAddPhoto = false;
  }

  cancelFlow() {
    this.displayPhotoFlow = false;
    this.landingAddPhoto = true;
  }

  photoUploaded() {
    this.router.navigate(['/']);
  }
}
