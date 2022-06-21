import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'front-end-find-organisation',
  templateUrl: './find-organisation.component.html',
  styleUrls: ['./find-organisation.component.css']
})
export class FindOrganisationComponent {
  @Output()
  public continue = new EventEmitter<boolean>();

  constructor() {
    //
  }

  done() {
    this.continue.emit(true);
  }
}