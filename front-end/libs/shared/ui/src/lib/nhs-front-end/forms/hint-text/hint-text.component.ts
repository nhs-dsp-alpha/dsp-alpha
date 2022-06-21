import { Component, OnInit, Input, ChangeDetectionStrategy } from '@angular/core';
import { IParamsHintText } from '../../model/iparams-hint-text';

@Component({
  selector: 'nhs-hint-text',
  templateUrl: './hint-text.component.html',
  styleUrls: ['./hint-text.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HintTextComponent implements OnInit {
  @Input() params?: IParamsHintText;
  constructor() { }

  ngOnInit(): void {
  }

}
