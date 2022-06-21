import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';

import { of } from 'rxjs';
import { LogoComponent } from '../../logo/logo.component';

import { HeaderComponent } from './header.component';

describe('HeaderComponent', () => {
  let component: HeaderComponent;
  let fixture: ComponentFixture<HeaderComponent>;


    beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RouterTestingModule],
      providers: [
      ],
    declarations: [ HeaderComponent, LogoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render default header', () => {
    fixture = TestBed.createComponent(HeaderComponent);
    component = fixture.componentInstance;
    component.params = {
      "showNav": true,
      "showSearch": true,
      "primaryLinks": [
        {
          "url"  : "https://www.nhs.uk/conditions",
          "label" : "Health A-Z"
        },
        {
          'url' : 'https://www.nhs.uk/live-well/',
          'label' : 'Live Well'
        },
        {
          'url' : 'https://www.nhs.uk/mental-health/',
          'label' : 'Mental health'
        },
        {
          'url'  : 'https://www.nhs.uk/conditions/social-care-and-support/',
          'label' : 'Care and support'
        },
        {
          'url'  : 'https://www.nhs.uk/pregnancy/',
          'label' : 'Pregnancy'
        },
        {
          'url' : 'https://www.nhs.uk/nhs-services/',
          'label' : 'NHS services'
        }
      ]
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });

  it('should render service header', () => {
    fixture = TestBed.createComponent(HeaderComponent);
    component = fixture.componentInstance;
    component.params = {
      "service": {
        "name": "Digital service manual"
      },
      "showNav": true,
      "showSearch": true,
      "primaryLinks": [
          {
            "url"  : "#",
            "label" : "NHS service standard"
          },
          {
            'url' : '#',
            'label' : 'Design system'
          },
          {
            'url'  : '#',
            'label' : 'Content style guide'
          },
          {
            'url'  : '#',
            'label' : 'Accessibility'
          },
          {
            'url' : '#',
            'label' : 'Community and contribution'
          }
        ]
      }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });

  it('should render transactional header', () => {
    fixture = TestBed.createComponent(HeaderComponent);
    component = fixture.componentInstance;
    component.params = {
      "transactionalService": {
          "name": "Register with a GP",
          "href": "https://www.nhs.uk/nhs-services/gps/how-to-register-with-a-gp-surgery/"
        },
        "showNav": false,
        "showSearch": false
      }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });

  it('should render organisational header', () => {
    fixture = TestBed.createComponent(HeaderComponent);
    component = fixture.componentInstance;
    component.params = {
      "showNav": true,
      "showSearch": true,
      "organisation": {
        "name": "Anytown Anyplace",
        "split": "Anywhere",
        "descriptor": "NHS Foundation Trust",
        logoURL:''
      },
      "primaryLinks": [
        {
          "url"  : "#",
          "label" : "Your hospital visit"
        },
        {
          'url' : '#',
          'label' : 'Wards and departments'
        },
        {
          'url'  : '#',
          'label' : 'Conditions and treatments'
        },
        {
          'url'  : '#',
          'label' : 'Our people'
        },
        {
          'url' : '#',
          'label' : 'Our research'
        }
      ]
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });

  it('should render white variant', () => {
    fixture = TestBed.createComponent(HeaderComponent);
    component = fixture.componentInstance;
    component.params = {
      "showNav": true,
      "showSearch": true,
      "classes": "nhsuk-header--white",
      "organisation": {
        "name": "Anytown Anyplace",
        "split": "Anywhere",
        "descriptor": "NHS Foundation Trust",
        logoURL:''
      },
      "primaryLinks": [
        {
          "url"  : "#",
          "label" : "Your hospital visit"
        },
        {
          'url' : '#',
          'label' : 'Wards and departments'
        },
        {
          'url'  : '#',
          'label' : 'Conditions and treatments'
        },
        {
          'url'  : '#',
          'label' : 'Our people'
        },
        {
          'url' : '#',
          'label' : 'Our research'
        }
      ]
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });
});
