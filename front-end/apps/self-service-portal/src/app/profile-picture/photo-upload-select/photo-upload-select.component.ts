import { Component, Output, EventEmitter, Input } from '@angular/core';

@Component({
  selector: 'self-service-photo-upload-select',
  templateUrl: './photo-upload-select.component.html',
  styleUrls: ['./photo-upload-select.component.scss'],
})
export class PhotoUploadSelectComponent {
  @Output() public continue = new EventEmitter<string>();
  @Output() public cancel = new EventEmitter<boolean>();
  @Input() heading = '';

  uploadedImage = '';
  errorMessage = '';

  takePhoto() {
    this.continue.emit("webcam");
  }


  // Receives image from either upload or camera
  imageUploadedEvent(uploadedImage: string) {
    this.uploadedImage = uploadedImage;
    this.continue.emit(uploadedImage);
  }

  // Displays error messages from file upload
  errorMessageEvent(errorMessage: string) {
    console.log(errorMessage);
    this.errorMessage = errorMessage;
  }

}
