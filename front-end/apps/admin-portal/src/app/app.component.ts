import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { firstValueFrom } from 'rxjs'

@Component({
  selector: 'admin-portal-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'admin-portal';

  constructor(private http: HttpClient) {
    // this.checkStatus();
  }

  public async checkStatus(): Promise<void> {
    console.log('AuthenticationService:checkStatus');
    const req = this.http.get('user');

    await firstValueFrom(req)
    .then(async () => {
      await firstValueFrom(this.http.get('api/api'));
    })
    .catch(reason => {
      window.alert(reason);
    });
  }
}
