import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { IParamsSkipLink } from '../../model/iparams-skip-link';

@Component({
  selector: 'nhs-skip-link',
  templateUrl: './skip-link.component.html',
  styleUrls: ['./skip-link.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SkipLinkComponent implements OnInit {
  @Input() params!: IParamsSkipLink;

  constructor() { }

  ngOnInit(): void {
  }

}
