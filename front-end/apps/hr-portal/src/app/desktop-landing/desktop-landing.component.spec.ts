import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DesktopLandingComponent } from './desktop-landing.component';

describe('DesktopLandingComponent', () => {
  let component: DesktopLandingComponent;
  let fixture: ComponentFixture<DesktopLandingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DesktopLandingComponent],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DesktopLandingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
