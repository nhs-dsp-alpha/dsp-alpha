import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FooterComponent } from './footer.component';

describe('FooterComponent', () => {
  let component: FooterComponent;
  let fixture: ComponentFixture<FooterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FooterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FooterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render', () => {
    fixture = TestBed.createComponent(FooterComponent);
    component = fixture.componentInstance;
    component.params = {
      "links": [
        {
          "URL": "#",
          "label": "Accessibility statement"
        },
        {
          "URL": "#",
          "label": "Contact us"
        },
        {
          "URL": "#",
          "label": "Cookies"
        },
        {
          "URL": "#",
          "label": "Privacy policy"
        },
        {
          "URL": "#",
          "label": "Terms and conditions"
        }
      ]
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });
});
