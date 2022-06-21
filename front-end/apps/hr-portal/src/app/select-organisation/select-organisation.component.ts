import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { organisations } from '@front-end/shared/services';
import { IParamsBackLink } from '@front-end/shared/ui';
import { Observable } from 'rxjs';

@Component({
  selector: 'hr-portal-select-organisation',
  templateUrl: './select-organisation.component.html',
  styleUrls: ['./select-organisation.component.scss'],
})
export class SelectOrganisationComponent implements OnInit {
  @Output()
  public continue = new EventEmitter<boolean>();
  @Output()
  public cancel = new EventEmitter();
  @Output()
  public organisationSelected = new EventEmitter<string | undefined>();
  @Input()
  public organisations$?: Observable<organisations.Organisation[]>;

  backlink: IParamsBackLink = { href: undefined, routerLink: '#', text: 'Back', clickable: true };

  organisationId = '';

  constructor() {
    //
  }

  public get selected(): boolean {
    return !!this.organisationId;
  }

  ngOnInit(): void {
    // Remove previously selected Org
    this.organisationSelected.emit(undefined);
  }

  done() {
    this.organisationSelected.emit(this.organisationId);
  }

  goBack() {
    this.cancel.emit();
  }
}
