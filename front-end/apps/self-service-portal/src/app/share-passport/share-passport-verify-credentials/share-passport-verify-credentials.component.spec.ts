import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SharePassportVerifyCredentialsComponent } from './share-passport-verify-credentials.component';

describe('SharePassportVerifyCredentialsComponent', () => {
  let component: SharePassportVerifyCredentialsComponent;
  let fixture: ComponentFixture<SharePassportVerifyCredentialsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SharePassportVerifyCredentialsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SharePassportVerifyCredentialsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
