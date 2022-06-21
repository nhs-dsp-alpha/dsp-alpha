import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import { IParamsInsetText } from '../../model/iparams-inset-text';

@Component({
  selector: 'nhs-inset-text',
  templateUrl: './inset-text.component.html',
  styleUrls: ['./inset-text.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class InsetTextComponent implements OnInit {
  @Input() params!: IParamsInsetText;

  constructor(private sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    if (this.params?.html) {
      this.params.safeHtml = this.sanitizer.bypassSecurityTrustHtml(this.params.html);
    }
  }

}
