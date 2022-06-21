import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { firstValueFrom } from 'rxjs'

import { environment } from '../environments/environment';

const CheckForPopupClosedInterval = 500;
const DefaultPopupFeatures = 'directories=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,scrollbars=no,resizable=no,width=500,height=500,left=100,top=100;';
//const DefaultPopupFeatures = 'location=no,toolbar=no,width=500,height=500,left=100,top=100;resizable=yes';

const DefaultPopupTarget = "_blank";

@Component({
  selector: 'front-end-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'front-end';

  private windowProxy: WindowProxy | null = null;
  public result = '';
  public signedIn = false;

  constructor(private http: HttpClient) {
  }

  ngOnInit(): void {
    try {
      this.showResult("user")
      .then(() => {
        this.signedIn = true;
      })
      .catch(() => {
        this.signedIn = false;
      });
    // eslint-disable-next-line no-empty
    } catch (error) {
    }
  }

  public get SignedInStatus() {
    return this.signedIn ? "You are signed in" : "You are not signed in";
  }

  public Login() {
    this.NavigateTo("login")
  }

  public Logout() {
    this.NavigateTo("logout")
  }

  public Profile() {
    this.NavigateTo("microsoftidentity/account/editprofile")
  }

  public Password() {
    this.NavigateTo("microsoftidentity/account/resetpassword")
  }

  public ShowIssue() {
    this.showWindow("issue")
      .then(path => this.showResult(path));
  }

  public ShowVerify() {
    this.showWindow("verify")
      .then(path => this.showResult(path));
  }

  private NavigateTo(path: string) {
    const baseUrl = environment.redirectBaseUrl;
    const url = `${baseUrl}/${path.toLowerCase()}`;

    window.location.assign(url);
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
    this.result = JSON.stringify(await this.checkResult(path));
  }

  private showWindow(path: string, redirectUrl: string = "processing"): Promise<string> {
    const baseUrl = environment.redirectBaseUrl;
    const url = `${baseUrl}/${path.toLowerCase()}?redirecturi=${baseUrl}/${redirectUrl}`;
    const target = DefaultPopupTarget;
    const features = DefaultPopupFeatures;

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
}

