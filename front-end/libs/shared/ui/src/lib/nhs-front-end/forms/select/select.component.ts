import { Component, OnInit, Input, ChangeDetectionStrategy } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { IParamsSelect } from '../../model/iparams-select';

@Component({
  selector: 'nhs-select',
  templateUrl: './select.component.html',
  styleUrls: ['./select.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SelectComponent implements OnInit {
  @Input() params!: IParamsSelect;
  @Input() parentGroup!: FormGroup;
  constructor() { }

  ngOnInit(): void {
  }

}
