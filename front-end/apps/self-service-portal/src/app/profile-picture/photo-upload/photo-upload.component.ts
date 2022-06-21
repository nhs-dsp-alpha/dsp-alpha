import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'self-service-photo-upload',
  templateUrl: './photo-upload.component.html',
  styleUrls: ['./photo-upload.component.scss'],
})
export class PhotoUploadComponent {
  @Input() requiredFileType: string;
  @Output() imageUrl = new EventEmitter<string>();
  @Output() errorMessage = new EventEmitter<string>();

  constructor(private http: HttpClient) {
    this.requiredFileType = "";
  }

  onFileSelected(event: any) {

    if (this.checkFile(event) === false) { return; }

    this.displayFile(event);
  }

  checkFile(event: any): boolean {
    // Check file has been uploaded
    if (!event.target.files[0] || event.target.files[0].length == 0) {
      this.errorMessage.emit('You must select an image');
      return false;
    }

    // Check file is image
    const mimeType = event.target.files[0].type;
    if (mimeType.match(/image\/*/) == null) {
      this.errorMessage.emit('You must select an image');
      return false;
    }

    // All checks passed return true
    return true;
  }

  displayFile(event: any) {
    const reader = new FileReader();
    reader.readAsDataURL(event.target.files[0]);

    reader.onload = (_event) => {
      this.errorMessage.emit('');
      const result = reader.result ?? '';
      this.imageUrl.emit(result.toString());
    }
  }
}
