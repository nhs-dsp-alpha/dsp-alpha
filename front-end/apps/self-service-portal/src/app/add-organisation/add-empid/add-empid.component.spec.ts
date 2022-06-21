import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEmpidComponent } from './add-empid.component';

describe('AddEmpidComponent', () => {
  let component: AddEmpidComponent;
  let fixture: ComponentFixture<AddEmpidComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEmpidComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEmpidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
