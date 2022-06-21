import { Component, Input, Output, EventEmitter } from '@angular/core';
import { container } from '@front-end/shared/services';
import { IParamsBackLink } from '@front-end/shared/ui';

const MAX_IMG_SIZE = 80000;

@Component({
  selector: 'self-service-profile-picture-flow',
  templateUrl: './profile-picture-flow.component.html',
  styleUrls: ['./profile-picture-flow.component.scss'],
})
export class ProfilePictureFlowComponent {
  @Input() heading = '';
  @Output() public cancel = new EventEmitter<boolean>();
  @Output() public continue = new EventEmitter<string>();

  containerService: container.ContainerService;

  backlink: IParamsBackLink = { href: undefined, routerLink: '#', text: 'Back', clickable: true };


  displayImageChoice = true;
  public displayWebCam = false;
  public confirmImage = false;

  imageUrl = '';

  constructor(private _containerService: container.ContainerService) {
    this.containerService = _containerService;
  }


  photoUploadSelectContinue(imageChoice: string) {
    this.displayImageChoice = false;
    switch (imageChoice) {
      case "webcam": {
        this.displayWebCam = true;
        break;
      }
      default: { //Image Url string
        this.imageUrl = imageChoice;
        break;
      }
    }

  }

  handleWebcamImage(image: string) {
    this.imageUrl = image;
  }

  uploadImage(image: string) {
    this.continue.emit(image);
  }

  removeImage() {
    this.imageUrl = '';
    this.displayImageChoice = true
  }

  goBack() {
    this.cancel.emit(true);
  }
}
