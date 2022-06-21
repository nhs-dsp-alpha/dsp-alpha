import { Component, OnInit, ChangeDetectionStrategy, Input, Output, EventEmitter } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { IParamsClickable } from '../../model/iparams-clickable';
import { IParamsSummaryList } from '../../model/iparams-summary-list';

@Component({
  selector: 'nhs-summary-list',
  templateUrl: './summary-list.component.html',
  styleUrls: ['./summary-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SummaryListComponent implements OnInit {
  @Output()
  clicked = new EventEmitter<string>();
  @Input() params!: IParamsSummaryList;

  constructor(private sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this.params?.rows.forEach(row => {
      if (row.key.html) {
        row.key.safeHtml = this.sanitizer.bypassSecurityTrustHtml(row.key.html);
      }

      if (row.value.html) {
        row.value.safeHtml = this.sanitizer.bypassSecurityTrustHtml(row.value.html);
      }

      row.actions?.items.forEach(item => {
        if (item.html) {
          item.safeHtml = this.sanitizer.bypassSecurityTrustHtml(item.html);
        }
      })
    });
  }

  onClick(ev: Event, params: IParamsClickable) {
    this.clicked.emit(params.tag);
    return true;
  }
}
