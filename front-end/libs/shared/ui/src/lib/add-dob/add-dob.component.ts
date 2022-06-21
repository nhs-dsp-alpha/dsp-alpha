import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'front-end-add-dob',
  templateUrl: './add-dob.component.html',
  styleUrls: ['./add-dob.component.css']
})
export class AddDobComponent {
  @Output()
  public continue = new EventEmitter<Date>();

  @Input()
  public dob?: Date;

  public day = '';
  public month = '';
  public year = '';

  public get selected(): boolean {
    return !!this.day && !!this.month && !!this.year;
  }

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

  done() {
    this.continue.emit(new Date(Number.parseInt(this.year), Number.parseInt(this.month) - 1, Number.parseInt(this.day)));
  }
}
