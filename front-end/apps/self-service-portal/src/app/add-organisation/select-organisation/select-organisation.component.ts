import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { organisations } from '@front-end/shared/services';
import { IParamsBackLink } from '@front-end/shared/ui';
import { Observable } from 'rxjs';

@Component({
  selector: 'self-service-select-organisation',
  templateUrl: './select-organisation.component.html',
  styleUrls: ['./select-organisation.component.scss']
})
export class SelectOrganisationComponent implements OnInit {
  @Output()
  public continue = new EventEmitter<boolean>();
  @Output()
  public organisationSelected = new EventEmitter<string>();
  @Output()
  public cancel = new EventEmitter<boolean>();
  @Input()
  public organisations$?: Observable<organisations.Organisation[]>;

  backlink: IParamsBackLink = { href: undefined, routerLink: '#', text: 'Back', clickable: true };

  organisationCode = '';

  constructor() {
    //
  }

  public get selected(): boolean {
    return !!this.organisationCode;
  }

  ngOnInit(): void {
    console.log();
  }

  goBack() {
    this.cancel.emit(true);
    return false;
  }

  onOrganisationSelected(orgCode: string) {
    console.log("Organisation selected: ", this.organisationCode);
    this.organisationSelected.emit(orgCode);
    this.continue.emit(true);
  }
}
