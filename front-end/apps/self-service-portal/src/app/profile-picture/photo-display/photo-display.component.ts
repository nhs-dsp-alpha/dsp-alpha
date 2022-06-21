import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IParamsBackLink } from '@front-end/shared/ui';

@Component({
  selector: 'self-service-photo-display',
  templateUrl: './photo-display.component.html',
  styleUrls: ['./photo-display.component.scss'],
})
export class PhotoDisplayComponent {
  @Output() public continue = new EventEmitter<string>();
  @Output() public cancel = new EventEmitter<boolean>();
  @Input() heading = '';
  @Input() imageUrl = '';

  backlink: IParamsBackLink = { href: undefined, routerLink: '#', text: 'Back', clickable: true };
  confirmPhoto() {
    this.continue.emit(this.imageUrl);
  }

  goBack() {
    this.cancel.emit(true);
  }
}
