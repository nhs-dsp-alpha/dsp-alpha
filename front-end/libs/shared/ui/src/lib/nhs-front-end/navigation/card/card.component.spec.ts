import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';

import { CardComponent } from './card.component';

describe('CardComponent', () => {
  let component: CardComponent;
  let fixture: ComponentFixture<CardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RouterTestingModule],
      declarations: [ CardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render a basic card', () => {
    fixture = TestBed.createComponent(CardComponent);
    component = fixture.componentInstance;
    component.params = {
      "heading": "If you need help now, but it’s not an emergency",
      "headingLevel": 3,
      "descriptionHtml": "<p class=\"nhsuk-card__description\">Go to <a href=\"#\">111.nhs.uk</a> or <a href=\"#\">call 111</a></p>"
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });

  it('should render a clickable card', () => {
    fixture = TestBed.createComponent(CardComponent);
    component = fixture.componentInstance;
    component.params = {
      "href": "#",
      "clickable": true,
      "heading": "Introduction to care and support",
      "headingClasses": "nhsuk-heading-m",
      "description": "A quick guide for people who have care and support needs and their carers"
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });

  it('should render an image card', () => {
    fixture = TestBed.createComponent(CardComponent);
    component = fixture.componentInstance;
    component.params = {
      "imgURL": "https://assets.nhs.uk/prod/images/A_0218_exercise-main_FKW1X7.width-690.jpg",
      "href": "#",
      "clickable": true,
      "heading": "Exercise",
      "headingClasses": "nhsuk-heading-m",
      "description": "Programmes, workouts and tips to get you moving and improve your fitness and wellbeing"
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });
});
