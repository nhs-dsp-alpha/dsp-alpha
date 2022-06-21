import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';

import { ENV } from '../../../../env';

const CheckForPopupClosedInterval = 500;
const DefaultPopupFeatures = 'directories=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,scrollbars=no,resizable=no,width=500,height=500,left=100,top=100;';
const DefaultPopupTarget = "_blank";

@Injectable()
export class IssueVerifyService {
  private windowProxy: WindowProxy | null = null;

  constructor(
    private http: HttpClient,
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    @Inject(ENV) private environment: any) {
  }

  public ShowIssue() {
    return this.showWindow("issue")
      .then(path => this.showResult(path));
  }

  public ShowVerify(credentialType: string = 'PrimaryIdentityCredential', credentialIssuer: string = 'PostOffice') {
    credentialType = `/${credentialType}`;
    credentialIssuer = `/${credentialIssuer}`;
    return this.showWindow("verify", "processing", credentialType, credentialIssuer)
      .then(path => this.showResult(path));
  }

  public async checkResult(path: string): Promise<unknown> {
    let resultPath = "issued";

    switch (path) {
      case "issue":
        resultPath = "issued";
        break;

      case "verify":
        resultPath = "verified";
        break;

      default:
        resultPath = path;
        break;
    }
    console.log('Front-end:checkIssued');
    const req = this.http.get(`/${resultPath}`);


    return firstValueFrom(req).then(obj => {
      return obj;
    });

    // await firstValueFrom(req)
    //   .then(async () => {
    //     await firstValueFrom(this.http.get('api/api'));
    //   })
    //   .catch(reason => {
    //     window.alert(reason);
    //   });
  }

  private closePopup() {
    try {
      if (this.windowProxy && !this.windowProxy.closed) {
        this.windowProxy.close();
      }

      this.windowProxy = null;
    } catch (error) {
      console.error(error);
    }
  }

  private async showResult(path: string) {
    return JSON.stringify(await this.checkResult(path));
  }

  private showWindow(path: string, redirectUrl: string = "processing", credentialType: string = '', credentialIssuer: string = ''): Promise<string> {
    const baseUrl = this.environment.redirectBaseUrl;
    const url = `${baseUrl}/${path.toLowerCase()}${credentialType}${credentialIssuer}?redirecturi=${baseUrl}/${redirectUrl}`;
    const target = DefaultPopupTarget;
    const features = DefaultPopupFeatures;

    console.log(url);

    const promise = new Promise<string>((resolve, reject) => {

      if (!this.windowProxy) {
        this.windowProxy = window.open(url, target, features);
        if (this.windowProxy) {
          let processed = false;
          const timer = setInterval(() => {
            try {
              if (this.windowProxy && this.windowProxy.closed) {
                processed = true;
              } else if (this.windowProxy && (encodeURI(this.windowProxy.location.href).indexOf(encodeURI(redirectUrl)) != -1)) {
                processed = true;
              }

              if (processed) {
                clearInterval(timer);
                this.closePopup();
                resolve(path);
              }
              // eslint-disable-next-line no-empty
            } catch (e) {
            }
          }, CheckForPopupClosedInterval);
        }
      } else {
        this.windowProxy.location.href = url;
        reject(path);
      }
    });

    return promise;
  }
}
