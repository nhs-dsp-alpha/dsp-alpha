import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { IParamsWarningCallout } from '../../model/iparams-warning-callout';


@Component({
  selector: 'nhs-warning-callout',
  templateUrl: './warning-callout.component.html',
  styleUrls: ['./warning-callout.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})

export class WarningCalloutComponent implements OnInit {
  @Input() params!: IParamsWarningCallout;
  headingLevel: number = 3;

  constructor(private sanitizer: DomSanitizer) {
  }
  
  ngOnInit(): void {
    this.headingLevel = this.params?.headingLevel || 3;

    if (this.params?.html) {
      this.params.safeHtml = this.sanitizer.bypassSecurityTrustHtml(this.params.html);
    }
  }

  public get containsImportant(): boolean {
    return this.params && this.params.heading.indexOf("mportant") > 0;
  }
}
