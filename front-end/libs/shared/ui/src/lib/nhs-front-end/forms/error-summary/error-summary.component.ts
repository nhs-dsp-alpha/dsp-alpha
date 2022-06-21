import { Component, OnInit, Input, ChangeDetectionStrategy } from '@angular/core';
import { IParamsErrorSummary } from '../../model/iparams-error-summary';



@Component({
  selector: 'app-error-summary',
  templateUrl: './error-summary.component.html',
  styleUrls: ['./error-summary.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ErrorSummaryComponent implements OnInit {
  @Input() params!: IParamsErrorSummary;
  constructor() { }

  get title(): string | undefined {
    return this.params?.titleText ? this.params?.titleText : this.params?.titleHtml;
  }
  ngOnInit(): void {
  }

}
