import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SharePassportShareCredentialsComponent } from './share-passport-share-credentials.component';

describe('SharePassportShareCredentialsComponent', () => {
  let component: SharePassportShareCredentialsComponent;
  let fixture: ComponentFixture<SharePassportShareCredentialsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SharePassportShareCredentialsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SharePassportShareCredentialsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
