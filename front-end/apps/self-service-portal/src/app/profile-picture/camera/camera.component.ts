import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IParamsBackLink } from '@front-end/shared/ui';
import { WebcamImage, WebcamInitError, WebcamUtil } from 'ngx-webcam';
import { Observable, Subject } from 'rxjs';

@Component({
  selector: 'self-service-camera',
  templateUrl: './camera.component.html',
  styleUrls: ['./camera.component.scss'],
})
export class CameraComponent implements OnInit {
  @Output() public continue = new EventEmitter<string>();
  @Output() public cancel = new EventEmitter<boolean>();
  @Input() heading = '';
  @Input() showWebcam = true;
  isCameraExist = true;
  innerWidth = 20;
  backlink: IParamsBackLink = { href: undefined, routerLink: '#', text: 'Back', clickable: true };

  errors: WebcamInitError[] = [];

  // webcam snapshot trigger
  private trigger: Subject<void> = new Subject<void>();
  private nextWebcam: Subject<boolean | string> = new Subject<boolean | string>();


  ngOnInit(): void {
    this.showWebcam = false;
    this.showWebcam = true;
    WebcamUtil.getAvailableVideoInputs()
      .then((mediaDevices: MediaDeviceInfo[]) => {
        this.isCameraExist = mediaDevices && mediaDevices.length > 0;
      });

    // Potentially could be wrapped in service to reduce width based on screen size
    this.innerWidth = window.innerWidth - 32;
  }

  takeSnapshot(): void {
    this.trigger.next();
  }

  onOffWebCam() {
    this.showWebcam = !this.showWebcam;
  }

  handleInitError(error: WebcamInitError) {
    this.errors.push(error);
  }

  changeWebCam(directionOrDeviceId: boolean | string) {
    this.nextWebcam.next(directionOrDeviceId);
  }

  handleImage(webcamImage: WebcamImage) {
    // this.showWebcam = false;
    this.continue.emit(webcamImage.imageAsDataUrl);
  }

  goBack() {
    // this.showWebcam = false;
    this.cancel.emit(true);
  }

  get triggerObservable(): Observable<void> {
    return this.trigger.asObservable();
  }

  get nextWebcamObservable(): Observable<boolean | string> {
    return this.nextWebcam.asObservable();
  }
}
