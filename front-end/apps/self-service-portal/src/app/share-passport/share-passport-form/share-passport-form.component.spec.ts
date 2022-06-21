import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SharePassportFormComponent } from './share-passport-form.component';

describe('SharePassportFormComponent', () => {
  let component: SharePassportFormComponent;
  let fixture: ComponentFixture<SharePassportFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SharePassportFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SharePassportFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
