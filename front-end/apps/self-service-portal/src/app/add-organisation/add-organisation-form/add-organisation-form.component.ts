import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { organisations } from '@front-end/shared/services';

@Component({
  selector: 'self-service-add-organisation-form',
  templateUrl: './add-organisation-form.component.html',
  styleUrls: ['./add-organisation-form.component.scss']
})
export class AddOrganisationFormComponent implements OnInit {
  @Output()
  public continue = new EventEmitter<boolean>();
  @Output()
  public changePhoto = new EventEmitter<boolean>();
  @Output()
  public changeOrganisation = new EventEmitter<boolean>();
  @Output()
  public changeEmployeeId = new EventEmitter<boolean>();
  @Output()
  public changeDob = new EventEmitter<boolean>();

  @Input()
  busy?: boolean;

  @Input()
  public photoString = '';
  @Input()
  selectedOrganisation?: organisations.Organisation;
  @Input()
  public employeeId = '';
  @Input()
  public dob?: Date;
  public dateOfBirth = '';

  constructor() {
    //
  }

  ngOnInit(): void {
    this.dateOfBirth = this.dob ? this.dob.toDateString() : '';
  }

  done() {
    this.continue.emit(true);
  }

  onchangePhoto() {
    this.changePhoto.emit(true);
    return false;
  }

  onchangeOrganisation() {
    this.changeOrganisation.emit(true);
    return false;
  }

  onChangeEmployeeId() {
    this.changeEmployeeId.emit(true);
    return false;
  }

  onChangeDob() {
    this.changeDob.emit(true);
    return false;
  }
}
