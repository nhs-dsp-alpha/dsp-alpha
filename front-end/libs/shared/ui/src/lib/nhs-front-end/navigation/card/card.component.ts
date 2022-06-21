import { Component, OnInit, ChangeDetectionStrategy, Input, EventEmitter, Output } from '@angular/core';
import { DomSanitizer, SafeHtml } from "@angular/platform-browser";
import { IParamsCard } from '../../model/iparams-card';

@Component({
  selector: 'nhs-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CardComponent implements OnInit {
  @Output()
  clicked = new EventEmitter();
  @Input() params!: IParamsCard;

  headingLevel = 2;

  constructor(private sanitizer: DomSanitizer) {
    this.params = {
      heading: "If you need help now, but it’s not an emergency",
      headingLevel: 3,
      descriptionHtml: "<p class=\"nhsuk-card__description\">Go to <a href=\"#\">111.nhs.uk</a> or <a href=\"#\">call 111</a></p>"
    }
  }

  ngOnInit(): void {
    this.headingLevel = this.params.headingLevel || 2;

    if (this.params.headingHtml) {
      this.params.headingSafeHtml = this.sanitizer.bypassSecurityTrustHtml(this.params.headingHtml);
    }

    if (this.params.descriptionHtml) {
      this.params.descriptionSafeHtml = this.sanitizer.bypassSecurityTrustHtml(this.params.descriptionHtml);
    }
  }

  onClick() {
    this.clicked.emit();
  }
}
