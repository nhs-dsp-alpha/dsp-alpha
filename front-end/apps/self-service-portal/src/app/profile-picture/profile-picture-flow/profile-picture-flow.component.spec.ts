import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfilePictureFlowComponent } from './profile-picture-flow.component';

describe('ProfilePictureFlowComponent', () => {
  let component: ProfilePictureFlowComponent;
  let fixture: ComponentFixture<ProfilePictureFlowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProfilePictureFlowComponent],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfilePictureFlowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
