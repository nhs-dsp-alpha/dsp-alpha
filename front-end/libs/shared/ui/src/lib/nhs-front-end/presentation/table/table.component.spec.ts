import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableComponent } from './table.component';

describe('TableComponent', () => {
  let component: TableComponent;
  let fixture: ComponentFixture<TableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render a 2 column table', () => {
    fixture = TestBed.createComponent(TableComponent);
    component = fixture.componentInstance;

    component.params = {
      panel: false,
      caption: "Skin symptoms and possible causes",
      firstCellIsHeader: false,
      head: [
        {
          text: "Skin symptoms"
        },
        {
          text: "Possible cause"
        }
      ],
      rows: [
        [
          {
            text: "Blisters on lips or around the mouth"
          },
          {
            text: "cold sores"
          }
        ],
        [
          {
            text: "Itchy, dry, cracked, sore"
          },
          {
            text: "eczema"
          }
        ],
        [
          {
            text: "Itchy blisters"
          },
          {
            text: "shingles, chickenpox"
          }
        ]
      ]
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });

  it('should render a 3 or more column table', () => {
    fixture = TestBed.createComponent(TableComponent);
    component = fixture.componentInstance;

    component.params = {
      responsive: true,
      panel: false,
      caption: "Ibuprofen tablet dosages for children",
      firstCellIsHeader: false,
      head: [
        {
          text: "Age"
        },
        {
          text: "How much"
        },
        {
          text: "How often"
        }
      ],
      rows: [
        [
          {
            // header: "Age",
            text: "7 to 9 years"
          },
          {
            // header: "How much?",
            text: "200mg"
          },
          {
            // header: "How often?",
            text: "Max 3 times in 24 hours"
          }
        ],
        [
          {
            // header: "Age",
            text: "10 to 11 years"
          },
          {
            // header: "How much?",
            text: "200mg to 300mg"
          },
          {
            // header: "How often?",
            text: "Max 3 times in 24 hours"
          }
        ],
        [
          {
            // header: "Age",
            text: "12 to 17 years"
          },
          {
            // header: "How much?",
            text: "200mg to 400mg"
          },
          {
            // header: "How often?",
            text: "Max 3 times in 24 hours"
          }
        ]
      ]
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });
});
