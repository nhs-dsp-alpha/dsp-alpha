import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { IParamsBackLink } from '@front-end/shared/ui';

@Component({
  selector: 'self-service-share-passport-find-organisation',
  templateUrl: './share-passport-find-organisation.component.html',
  styleUrls: ['./share-passport-find-organisation.component.css']
})
export class SharePassportFindOrganisationComponent implements OnInit {
  @Output()
  public continue = new EventEmitter<boolean>();
  @Output()
  public cancel = new EventEmitter<boolean>();

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

  done() {
    this.continue.emit(true);
  }
}