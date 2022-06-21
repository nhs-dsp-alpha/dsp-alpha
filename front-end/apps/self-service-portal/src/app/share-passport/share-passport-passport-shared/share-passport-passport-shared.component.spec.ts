import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SharePassportPassportSharedComponent } from './share-passport-passport-shared.component';

describe('SharePassportPassportSharedComponent', () => {
  let component: SharePassportPassportSharedComponent;
  let fixture: ComponentFixture<SharePassportPassportSharedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SharePassportPassportSharedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SharePassportPassportSharedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
