import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDobComponent } from './add-dob.component';

describe('AddDobComponent', () => {
  let component: AddDobComponent;
  let fixture: ComponentFixture<AddDobComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddDobComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddDobComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
