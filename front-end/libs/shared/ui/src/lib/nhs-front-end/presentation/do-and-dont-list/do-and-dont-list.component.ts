import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { IParamsDoAndDontList } from '../../model/iparams-do-and-dont-list';

@Component({
  selector: 'nhs-do-and-dont-list',
  templateUrl: './do-and-dont-list.component.html',
  styleUrls: ['./do-and-dont-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DoAndDontListComponent implements OnInit {
  @Input() params!: IParamsDoAndDontList;
  headingLevel: number = 3;

  constructor() { }

  ngOnInit(): void {
    this.headingLevel = this.params?.headingLevel || 3;
  }
}
