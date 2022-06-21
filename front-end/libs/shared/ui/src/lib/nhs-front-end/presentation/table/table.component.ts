import { Component, OnInit, ChangeDetectionStrategy, Input, Output, EventEmitter } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { IParamsClickable } from '../../model/iparams-clickable';
import { IParamsTable } from '../../model/iparams-table';

@Component({
  selector: 'nhs-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TableComponent implements OnInit {
  @Output()
  clicked = new EventEmitter<string>();
  @Input() params!: IParamsTable;
  headingLevel = 3;

  constructor(private sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this.headingLevel = this.params?.headingLevel || 3;

    this.params?.head.forEach(cell => {
      if (cell.html) {
        cell.safeHtml = this.sanitizer.bypassSecurityTrustHtml(cell.html);
      }
    });

    this.params?.rows.forEach(row => {
      row.forEach(cell => {
        if (cell.html) {
          cell.safeHtml = this.sanitizer.bypassSecurityTrustHtml(cell.html);
        }
      });
    });
  }

  onClick(ev: Event, params: IParamsClickable) {
    this.clicked.emit(params.tag);
    return true;
  }
}
