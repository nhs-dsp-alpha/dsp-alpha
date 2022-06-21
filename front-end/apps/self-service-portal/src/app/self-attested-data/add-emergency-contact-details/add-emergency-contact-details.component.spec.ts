import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEmergencyContactDetailsComponent } from './add-emergency-contact-details.component';

describe('AddEmergencyContactDetailsComponent', () => {
  let component: AddEmergencyContactDetailsComponent;
  let fixture: ComponentFixture<AddEmergencyContactDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEmergencyContactDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEmergencyContactDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
