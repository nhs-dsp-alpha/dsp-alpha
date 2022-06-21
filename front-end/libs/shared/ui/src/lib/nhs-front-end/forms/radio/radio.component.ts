import { Component, OnInit, Input, ChangeDetectionStrategy } from '@angular/core';
import { IParamsRadio } from '../../model/iparams-radio';


@Component({
  selector: 'nhs-radio',
  templateUrl: './radio.component.html',
  styleUrls: ['./radio.component.scss']
})
export class RadioComponent implements OnInit {
  @Input() params!: IParamsRadio;
  constructor() { }

  ngOnInit(): void {
  }

}
