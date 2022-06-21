import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CareCardComponent } from './care-card.component';

describe('CareCardComponent', () => {
  let component: CareCardComponent;
  let fixture: ComponentFixture<CareCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CareCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CareCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render a Non-urgent care card (blue)', () => {
    fixture = TestBed.createComponent(CareCardComponent);
    component = fixture.componentInstance;
    component.params = {
      type: "non-urgent",
      heading: "Speak to a GP if:",
      HTML: `
      <ul>
        <li>you're not sure it's chickenpox</li>
        <li>the skin around the blisters is red, hot or painful (signs of infection)</li>
        <li>your child is <a href=\"https://www.nhs.uk/conditions/dehydration\">dehydrated</a></li>
        <li>you're concerned about your child or they get worse</li>
      </ul>
      <p>Tell the receptionist you think it's chickenpox before going in. They may recommend a special appointment time if other patients are at risk.</p>
      `
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });

  it('should render an Urgent care card (red)', () => {
    fixture = TestBed.createComponent(CareCardComponent);
    component = fixture.componentInstance;
    component.params = {
      type: "urgent",
      heading: "Ask for an urgent GP appointment if:",
      HTML: `
      <ul>
        <li>you're an adult and have chickenpox</li>
        <li>you're pregnant and haven't had chickenpox before and you've been near someone with it </li>
        <li>you have a weakened immune system and you've been near someone with chickenpox</li>
        <li>you think your newborn baby has chickenpox</li>
      </ul>
       <p>In these situations, your GP can prescribe medicine to prevent complications. You need to take it within 24 hours of the spots coming out.</p>
      `
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });

  it('should render an Immediate care card (red and dark grey)', () => {
    fixture = TestBed.createComponent(CareCardComponent);
    component = fixture.componentInstance;
    component.params = {
      type: "immediate",
      heading: "Call 999 if you have sudden chest pain that:",
      HTML: `
      <ul>
        <li>spreads to your arms, back, neck or jaw</li>
        <li>makes your chest feel tight or heavy</li>
        <li>also started with shortness of breath, sweating and feeling or being sick</li>
      </ul>
      <p>You could be having a heart attack. Call 999 immediately as you need immediate treatment in hospital.</p>
      `
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });
});
