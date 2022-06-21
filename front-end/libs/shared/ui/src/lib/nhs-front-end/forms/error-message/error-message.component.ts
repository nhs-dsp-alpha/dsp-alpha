import { Component, OnInit, Input, ChangeDetectionStrategy } from '@angular/core';
import { IParamsErrorMessage } from '../../model/iparams-error-message';

@Component({
  selector: 'nhs-error-message',
  templateUrl: './error-message.component.html',
  styleUrls: ['./error-message.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ErrorMessageComponent implements OnInit {
  @Input() params?: IParamsErrorMessage;
  constructor() { }

  get title(): string | undefined {
    return this.params?.text ? this.params?.text : this.params?.html;
  }

  ngOnInit(): void {
  }

}
