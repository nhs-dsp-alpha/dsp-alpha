import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddStaffChoiceComponent } from './add-staff-choice.component';

describe('AddStaffChoiceComponent', () => {
  let component: AddStaffChoiceComponent;
  let fixture: ComponentFixture<AddStaffChoiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddStaffChoiceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddStaffChoiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
