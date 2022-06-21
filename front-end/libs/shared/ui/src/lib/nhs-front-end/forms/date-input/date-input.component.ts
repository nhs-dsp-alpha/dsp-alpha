import { Component, OnInit, Input, ChangeDetectionStrategy } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { IParamsDateInput } from '../../model/iparams-date-input';

@Component({
  selector: 'nhs-date-input',
  templateUrl: './date-input.component.html',
  styleUrls: ['./date-input.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DateInputComponent implements OnInit {
  @Input() params!: IParamsDateInput;
  @Input() parentGroup!: FormGroup;
  constructor() { }

  ngOnInit(): void {
  }

}
