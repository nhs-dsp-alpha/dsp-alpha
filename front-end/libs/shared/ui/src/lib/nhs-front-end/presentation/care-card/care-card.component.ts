import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { IParamsCareCard } from '../../model/iparams-care-card';

@Component({
  selector: 'nhs-care-card',
  templateUrl: './care-card.component.html',
  styleUrls: ['./care-card.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CareCardComponent implements OnInit {
  @Input() params!: IParamsCareCard;
  headingLevel: number = 3;

  constructor(private sanitizer: DomSanitizer) {
  }
  
  ngOnInit(): void {
    this.headingLevel = this.params?.headingLevel || 3;

    if (this.params?.HTML) {
      this.params.safeHTML = this.sanitizer.bypassSecurityTrustHtml(this.params.HTML);
    }
  }

  public get cardTypeClass(): string {
    return this.params?.type ? 'nhsuk-care-card--' + this.params?.type : '';
  }

  public get actionType(): string {
    let t = 'Non-urgent advice';

    if (this.params) {
      switch (this.params.type) {
        case 'non-urgent':
        default:
          t = 'Non-urgent advice';
          break;
        case 'urgent':
          t = 'Urgent advice';
          break;
        case 'immediate':
          t = 'Immediate action required';
          break;
      }
    }

    return t;
  }

}
