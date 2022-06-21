import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { IParamsImage } from '../../model/iparams-image';

@Component({
  selector: 'nhs-image',
  templateUrl: './image.component.html',
  styleUrls: ['./image.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ImageComponent implements OnInit {
  @Input() params!: IParamsImage;

  constructor() { }

  ngOnInit(): void {
  }

}
