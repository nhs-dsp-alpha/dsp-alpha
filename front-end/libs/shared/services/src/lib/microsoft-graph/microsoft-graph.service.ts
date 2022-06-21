import { Injectable } from '@angular/core';
import { ApiMsGraphService } from './api';

@Injectable({
  providedIn: 'root'
})
export class MicrosoftGraphService {

  constructor(private service: ApiMsGraphService) { }

  public getProfilePicture() {
    return this.service.getProfilePictureGet('');
  }

  public putProfilePicture(base64ImageString: string) {
    return this.service.putProfilePicturePost(base64ImageString, '');
  }
}
