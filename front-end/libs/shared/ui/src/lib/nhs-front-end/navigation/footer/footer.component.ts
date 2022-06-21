import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { IParamsFooter } from '../../model/iparams-footer';

@Component({
  selector: 'nhs-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class FooterComponent implements OnInit {
  @Input() params!: IParamsFooter;

  constructor() { }

  ngOnInit(): void {
  }
}
