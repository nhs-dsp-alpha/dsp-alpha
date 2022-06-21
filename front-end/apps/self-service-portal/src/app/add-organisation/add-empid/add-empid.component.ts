import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IParamsBackLink } from '@front-end/shared/ui';

@Component({
  selector: 'self-service-add-empid',
  templateUrl: './add-empid.component.html',
  styleUrls: ['./add-empid.component.scss']
})
export class AddEmpidComponent implements OnInit {
  @Output()
  public continue = new EventEmitter<string>();
  @Output()
  public cancel = new EventEmitter<boolean>();

  @Input()
  public employeeId = '';

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
    this.continue.emit(this.employeeId);
  }
}
