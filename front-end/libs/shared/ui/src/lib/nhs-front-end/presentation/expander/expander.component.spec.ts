import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExpanderComponent } from './expander.component';

describe('ExpanderComponent', () => {
  let component: ExpanderComponent;
  let fixture: ComponentFixture<ExpanderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExpanderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExpanderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render as expected', () => {
    fixture = TestBed.createComponent(ExpanderComponent);
    component = fixture.componentInstance;
    component.params = {
      "classes": "nhsuk-expander",
      "text": "Get your medical records",
      html: `
      <p>You can see your GP records by:</p>
      <ul>
        <li>asking for them at your GP surgery </li>
        <li>going online to see them (if you have signed up for <a href=\"/using-the-nhs/nhs-services/gps/gp-online-services/\">GP online services</a>) </li>
      </ul>`
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });
});
