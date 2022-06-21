import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { IParamsBackLink } from '@front-end/shared/ui';

@Component({
  selector: 'self-service-find-organisation',
  templateUrl: './find-organisation.component.html',
  styleUrls: ['./find-organisation.component.scss']
})
export class FindOrganisationComponent implements OnInit {
  @Output()
  public continue = new EventEmitter<boolean>();
  @Output()
  public cancel = new EventEmitter<boolean>();

  backlink: IParamsBackLink  = { href: undefined, routerLink:'#', text:'Back', clickable: true };

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
