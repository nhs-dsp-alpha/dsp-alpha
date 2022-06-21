import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IParamsBackLink } from '@front-end/shared/ui';

@Component({
  selector: 'self-service-share-passport-add-dob',
  templateUrl: './share-passport-add-dob.component.html',
  styleUrls: ['./share-passport-add-dob.component.css']
})
export class SharePassportAddDobComponent implements OnInit {
  @Output()
  public continue = new EventEmitter<Date>();
  @Output()
  public cancel = new EventEmitter<boolean>();

  @Input()
  public dob?: Date;

  public day = '';
  public month = '';
  public year = '';

  backlink: IParamsBackLink = { href: undefined, routerLink: '#', text: 'Back', clickable: true };

  constructor() {
    //
  }

  ngOnInit(): void {
    if (this.dob) {
      this.day = this.dob.getDate().toString();
      this.month = (this.dob.getMonth() + 1).toString();
      this.year = this.dob.getFullYear().toString();
    }
  }

  goBack() {
    this.cancel.emit(true);
    return false;
  }

  done(dateOfBirth: Date) {
    this.continue.emit(dateOfBirth);
  }
}
