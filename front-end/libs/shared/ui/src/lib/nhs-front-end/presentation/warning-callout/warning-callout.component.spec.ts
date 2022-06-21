import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WarningCalloutComponent } from './warning-callout.component';

describe('WarningCalloutComponent', () => {
  let component: WarningCalloutComponent;
  let fixture: ComponentFixture<WarningCalloutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WarningCalloutComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WarningCalloutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render', () => {
    fixture = TestBed.createComponent(WarningCalloutComponent);
    component = fixture.componentInstance;
    component.params = {
      "heading": "School, nursery or work",
      "html": "<p>Stay away from school, nursery or work until all the spots have crusted over. This is usually 5 days after the spots first appeared.</p>"
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });
});
