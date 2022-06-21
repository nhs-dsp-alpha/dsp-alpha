import { Component, OnInit, Input, ChangeDetectionStrategy } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { IParamsTextInput } from '../../model/iparams-text-input';

@Component({
  selector: 'nhs-text-input',
  templateUrl: './text-input.component.html',
  styleUrls: ['./text-input.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TextInputComponent implements OnInit {
  @Input() params!: IParamsTextInput;
  @Input() parentGroup!: FormGroup;
  constructor() { }

  ngOnInit(): void {
    if(this.params) {
      if(!this.params.type) {
        this.params.type = 'text';
      }
      if(!this.params.autocomplete) {
        this.params.autocomplete = 'off';
      }
    }
  }

}
