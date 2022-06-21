import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SharePassportComponent } from './share-passport.component';

describe('SharePassportComponent', () => {
  let component: SharePassportComponent;
  let fixture: ComponentFixture<SharePassportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SharePassportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SharePassportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
