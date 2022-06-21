import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthenticationService } from './authentication.service';
import { ENV } from '../../../env';

@NgModule({
  imports: [CommonModule],
})
export class SharedAuthenticationModule {
  public static forRoot(environment: { redirectBaseUrl: string }): ModuleWithProviders<SharedAuthenticationModule> {

    return {
      ngModule: SharedAuthenticationModule,
      providers: [
        AuthenticationService,
        {
          provide: ENV,
          useValue: environment
        }
      ]
    };
  }
}
