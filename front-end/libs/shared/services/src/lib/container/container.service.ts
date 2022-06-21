import { HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom, Observable } from 'rxjs';
import { ApiContainerService } from './api';

@Injectable({
  providedIn: 'root'
})
export class ContainerService {

  constructor(private service: ApiContainerService) { }

  public async putProfilePictureBlobPost(imageUrl: string): Promise<HttpResponse<any>> {
    const result$ = await this.service.putProfilePictureBlobPost(imageUrl, '', 'response');
    return lastValueFrom(result$);
  }

}
