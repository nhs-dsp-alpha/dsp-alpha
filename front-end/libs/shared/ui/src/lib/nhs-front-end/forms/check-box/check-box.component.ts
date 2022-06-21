import { Component, OnInit, Input, ChangeDetectionStrategy } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { IParamsCheckbox } from '../../model/iparams-checkbox';

@Component({
  selector: 'nhs-check-box',
  templateUrl: './check-box.component.html',
  styleUrls: ['./check-box.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CheckBoxComponent implements OnInit {
  @Input() params!: IParamsCheckbox;
  @Input() parentGroup!: FormGroup;
  constructor() { }

  ngOnInit(): void {
  }

}
