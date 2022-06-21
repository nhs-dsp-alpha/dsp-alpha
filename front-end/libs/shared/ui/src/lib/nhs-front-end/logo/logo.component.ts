import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';

@Component({
  selector: 'nhs-logo',
  templateUrl: './logo.component.html',
  styleUrls: ['./logo.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LogoComponent implements OnInit {
  @Input() inverse: boolean = false;
  private _background = '#005eb8';
  private _text = '#fff';

  constructor() { }

  ngOnInit(): void {
  }

  public get background() {
    return this.inverse ? this._text : this._background;
  }

  public get text() {
    return this.inverse ? this._background : this._text;
  }
}
