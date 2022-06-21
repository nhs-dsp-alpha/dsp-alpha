import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsComponent } from './details.component';

describe('DetailsComponent', () => {
  let component: DetailsComponent;
  let fixture: ComponentFixture<DetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render a details card', () => {
    fixture = TestBed.createComponent(DetailsComponent);
    component = fixture.componentInstance;
    component.params = {
      text: "How to find your NHS number",
      html: `
      <p>An NHS number is a 10 digit number, like 485 777 3456.</p>
        <p>You can find your NHS number by logging in to a GP online service or on any document the NHS has sent you, such as your:</p>
        <ul>
            <li>prescriptions</li>
            <li>test results</li>
            <li>hospital referral letters</li>
            <li>appointment letters</li>
        </ul>
        <p>Ask your GP surgery for help if you can't find your NHS number.</p>
      `
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });
});
