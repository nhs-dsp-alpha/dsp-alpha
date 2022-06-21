import { Component, OnInit, Input, ChangeDetectionStrategy } from '@angular/core';
import { IParamsButton } from '../../model/iparams-button';

@Component({
  selector: 'nhs-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ButtonComponent implements OnInit {
  @Input() params!: IParamsButton;

  constructor() { 


  }

  ngOnInit(): void {
    if(this.params) {
      if(!this.params.type) {
        this.params.type = 'submit';
      }
      if(!this.params.element && !this.params.href) {
        this.params.element = 'button';
      }
      if(!this.params.disabled) {
        this.params.disabled = false;
      }
    }
  }

}
