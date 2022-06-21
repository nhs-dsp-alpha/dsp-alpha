import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IParamsBackLink } from '@front-end/shared/ui';

@Component({
  selector: 'self-service-add-dob',
  templateUrl: './add-dob.component.html',
  styleUrls: ['./add-dob.component.scss']
})
export class AddDobComponent implements OnInit {
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
