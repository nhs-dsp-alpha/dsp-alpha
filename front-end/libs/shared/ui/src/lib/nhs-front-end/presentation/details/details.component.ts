import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { IParamsDetails } from '../../model/iparams-details';

@Component({
  selector: 'nhs-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DetailsComponent implements OnInit {
  @Input() params!: IParamsDetails;
  public isExpander: boolean = false;

  constructor(private sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    if (this.params?.html) {
      this.params.safeHtml = this.sanitizer.bypassSecurityTrustHtml(this.params.html);
    }
  }
}
