import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { IParamsActionLink } from '../../model/iparams-action-link';

@Component({
  selector: 'nhs-action-link',
  templateUrl: './action-link.component.html',
  styleUrls: ['./action-link.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ActionLinkComponent implements OnInit {
  @Input() params!: IParamsActionLink;

  constructor() {
    this.params = {
      text: "Find a minor injuries unit",
      href: "https://www.nhs.uk/service-search/minor-injuries-unit/locationsearch/551"
    }
  }

  ngOnInit(): void {
  }
}
