import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { IParamsTag } from '../../model/iparams-tag';



@Component({
  selector: 'nhs-tag',
  templateUrl: './tag.component.html',
  styleUrls: ['./tag.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TagComponent implements OnInit {
  @Input() params!: IParamsTag;

  constructor(private sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    if (this.params?.html) {
      this.params.safeHtml = this.sanitizer.bypassSecurityTrustHtml(this.params.html);
    }
  }
}
