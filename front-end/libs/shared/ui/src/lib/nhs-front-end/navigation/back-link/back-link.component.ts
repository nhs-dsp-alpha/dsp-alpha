import { Component, OnInit, ChangeDetectionStrategy, Input, Output, EventEmitter } from '@angular/core';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import { IParamsBackLink } from '../../model/iparams-back-link';

@Component({
  // eslint-disable-next-line @angular-eslint/component-selector
  selector: 'nhs-back-link',
  templateUrl: './back-link.component.html',
  styleUrls: ['./back-link.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BackLinkComponent implements OnInit {
  @Output()
  clicked = new EventEmitter<boolean>();

  @Input() params!: IParamsBackLink;

  constructor(private sanitizer: DomSanitizer) {
    // this.params = {
    //   text: "Go back"
    // }
  }

  ngOnInit(): void {
    if (this.params.html) {
      this.params.safeHtml = this.sanitizer.bypassSecurityTrustHtml(this.params.html);
    }
  }

  onClick() {
    this.clicked.emit(true);
    return true;
  }
}
