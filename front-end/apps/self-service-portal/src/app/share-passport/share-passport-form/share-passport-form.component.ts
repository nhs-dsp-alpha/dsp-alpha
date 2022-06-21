import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { organisations, credentialTypes } from '@front-end/shared/services';

@Component({
  selector: 'self-service-share-passport-form',
  templateUrl: './share-passport-form.component.html',
  styleUrls: ['./share-passport-form.component.css']
})
export class SharePassportFormComponent implements OnInit {
  @Output()
  public continue = new EventEmitter<boolean>();
  @Output()
  public changeOrganisation = new EventEmitter<boolean>();
  @Output()
  public changeDob = new EventEmitter<boolean>();
  @Output()
  public changeSharedInformation = new EventEmitter<boolean>();
  @Output()
  public changeMessage = new EventEmitter<boolean>();

  @Input()
  busy?: boolean;

  @Input()
  selectedOrganisation?: organisations.Organisation;
  @Input()
  public dob?: Date;
  public dateOfBirth = '';
  @Input()
  public typeOfSharedInformation: credentialTypes.CredentialType[] = [];
  @Input()
  public message = '';

  constructor() { }

  ngOnInit(): void {
    this.dateOfBirth = this.dob ? this.dob.toDateString() : '';
    console.log(this.selectedOrganisation);
  }

  done() {
    this.continue.emit(true);
  }

  onchangeOrganisation() {
    this.changeOrganisation.emit(true);
    return false;
  }

  onChangeDob() {
    this.changeDob.emit(true);
    return false;
  }

  onChangeSharedInformation() {
    this.changeSharedInformation.emit(true);
    return false;
  }

  onChangeMessage() {
    this.changeMessage.emit(true);
    return false;
  }

}
