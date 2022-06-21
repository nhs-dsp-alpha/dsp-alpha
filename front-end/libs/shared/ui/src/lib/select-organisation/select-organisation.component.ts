import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { organisations } from '@front-end/shared/services';
import { Observable } from 'rxjs';
@Component({
  selector: 'front-end-select-organisation',
  templateUrl: './select-organisation.component.html',
  styleUrls: ['./select-organisation.component.css']
})
export class SelectOrganisationComponent {
  @Output()
  public continue = new EventEmitter<boolean>();
  @Output()
  public organisationSelected = new EventEmitter<string>();
  @Output()
  public cancel = new EventEmitter<boolean>();
  @Input()
  public organisations$?: Observable<organisations.Organisation[]>;

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

  done() {
    console.log("Organisation selected: ", this.organisationCode);
    this.continue.emit(true);
    this.organisationSelected.emit(this.organisationCode);
  }
}