import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IParamsBackLink } from '@front-end/shared/ui';

@Component({
  selector: 'self-service-add-photo',
  templateUrl: './add-photo.component.html',
  styleUrls: ['./add-photo.component.scss']
})
export class AddPhotoComponent implements OnInit {
  @Output()
  public continue = new EventEmitter<string>();
  @Output()
  public cancel = new EventEmitter<boolean>();

  public photoAdded = false;

  heading = 'Add an NHS organisation';

  cancelLink: IParamsBackLink = { href: undefined, routerLink: '..', text: 'Back', clickable: false };
  backlink: IParamsBackLink = { href: undefined, routerLink: '#', text: 'Back', clickable: true };

  constructor() {
    //
  }

  ngOnInit(): void {
    console.log();
  }

  goBack() {
    this.cancel.emit(true);
    return false;
  }

  onPhotoAdded() {
    //this.photoUrl = "https://nhsuk-dsp-prototype.herokuapp.com/images/profile-pic.png";
    this.photoAdded = true;
  }

  notAdded() {
    this.photoAdded = false;
  }

  done(photoUrl: string) {
    this.continue.emit(photoUrl);
  }

  onSkipPhoto() {
    this.continue.emit('skip');
  }
}
