import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { IParamsBreadcrumbs } from '../../model/iparams-breadcrumbs';

@Component({
  selector: 'nhs-breadcrumbs',
  templateUrl: './breadcrumbs.component.html',
  styleUrls: ['./breadcrumbs.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BreadcrumbsComponent implements OnInit {
  @Input() params!: IParamsBreadcrumbs;
  
  constructor() { }

  ngOnInit(): void {
  }
}
