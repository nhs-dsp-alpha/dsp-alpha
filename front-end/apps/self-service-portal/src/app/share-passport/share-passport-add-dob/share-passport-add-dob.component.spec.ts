import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SharePassportAddDobComponent } from './share-passport-add-dob.component';

describe('SharePassportAddDobComponent', () => {
  let component: SharePassportAddDobComponent;
  let fixture: ComponentFixture<SharePassportAddDobComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SharePassportAddDobComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SharePassportAddDobComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
