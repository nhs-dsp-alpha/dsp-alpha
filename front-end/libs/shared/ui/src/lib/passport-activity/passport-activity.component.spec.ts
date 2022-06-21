import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PassportActivityComponent } from './passport-activity.component';

describe('PassportActivityComponent', () => {
  let component: PassportActivityComponent;
  let fixture: ComponentFixture<PassportActivityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PassportActivityComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PassportActivityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
