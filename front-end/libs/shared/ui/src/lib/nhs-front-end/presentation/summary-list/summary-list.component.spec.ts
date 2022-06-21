import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SummaryListComponent } from './summary-list.component';

describe('SummaryListComponent', () => {
  let component: SummaryListComponent;
  let fixture: ComponentFixture<SummaryListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SummaryListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SummaryListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render with actions', () => {
    fixture = TestBed.createComponent(SummaryListComponent);
    component = fixture.componentInstance;
    component.params = {
      rows: [
        {
          key: {
            text: "Name"
          },
          value: {
            text: "Karen Francis"
          },
          actions: {
            items: [
              {
                href: "#",
                text: "Change",
                visuallyHiddenText: "name"
              }
            ]
          }
        },
        {
          key: {
            text: "Date of birth"
          },
          value: {
            text: "15 March 1984"
          },
          actions: {
            items: [
              {
                href: "#",
                text: "Change",
                visuallyHiddenText: "date of birth"
              }
            ]
          }
        },
        {
          key: {
            text: "Contact information"
          },
          value: {
            html: "73 Roman Rd<br>Leeds<br> LS2 5ZN"
          },
          actions: {
            items: [
              {
                href: "#",
                text: "Change",
                visuallyHiddenText: "contact information"
              }
            ]
          }
        },
        {
          key: {
            text: "Contact details"
          },
          value: {
            html: '<p>07700 900362</p><p>karen.francis@example.com</p>'
          },
          actions: {
            items: [
              {
                href: "#",
                text: "Change",
                visuallyHiddenText: "contact details"
              }
            ]
          }
        }
      ]
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });

  it('should render without actions', () => {
    fixture = TestBed.createComponent(SummaryListComponent);
    component = fixture.componentInstance;
    component.params = {
      rows: [
        {
          key: {
            text: "Name"
          },
          value: {
            text: "Karen Francis"
          }
        },
        {
          key: {
            text: "Date of birth"
          },
          value: {
            text: "15 March 1984"
          }
        },
        {
          key: {
            text: "Contact information"
          },
          value: {
            html: "73 Roman Rd<br>Leeds<br> LS2 5ZN"
          }
        },
        {
          key: {
            text: "Contact details"
          },
          value: {
            html: '<p>07700 900362</p><p>karen.francis@example.com</p>'
          }
        }
      ]
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });

  it('should render without actions or borders', () => {
    fixture = TestBed.createComponent(SummaryListComponent);
    component = fixture.componentInstance;
    component.params = {
      classes: 'nhsuk-summary-list--no-border',
      rows: [
        {
          key: {
            text: "Name"
          },
          value: {
            text: "Karen Francis"
          }
        },
        {
          key: {
            text: "Date of birth"
          },
          value: {
            text: "15 March 1984"
          }
        },
        {
          key: {
            text: "Contact information"
          },
          value: {
            html: "73 Roman Rd<br>Leeds<br> LS2 5ZN"
          }
        },
        {
          key: {
            text: "Contact details"
          },
          value: {
            html: '<p>07700 900362</p><p>karen.francis@example.com</p>'
          }
        }
      ]
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });
});
