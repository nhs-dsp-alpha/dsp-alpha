import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddProfilePictureComponent } from './add-profile-picture/add-profile-picture.component';
import { SharedUiModule } from '@front-end/shared/ui';
import { FormsModule } from '@angular/forms';
import { CameraComponent } from './camera/camera.component';
import { PhotoUploadComponent } from './photo-upload/photo-upload.component';
import { PhotoDisplayComponent } from './photo-display/photo-display.component';
import { WebcamModule } from 'ngx-webcam';
import { PhotoUploadSelectComponent } from './photo-upload-select/photo-upload-select.component';
import { ProfilePictureFlowComponent } from './profile-picture-flow/profile-picture-flow.component';



@NgModule({
  declarations: [
    AddProfilePictureComponent,
    CameraComponent,
    PhotoUploadComponent,
    PhotoDisplayComponent,
    PhotoUploadSelectComponent,
    ProfilePictureFlowComponent,
  ],
  imports: [
    CommonModule,
    SharedUiModule,
    FormsModule,
    WebcamModule,
  ],
  exports: [
    AddProfilePictureComponent,
    CameraComponent,
    PhotoUploadComponent,
    PhotoDisplayComponent,
    PhotoUploadSelectComponent,
    ProfilePictureFlowComponent,
  ]
})
export class ProfilePictureModule { }
