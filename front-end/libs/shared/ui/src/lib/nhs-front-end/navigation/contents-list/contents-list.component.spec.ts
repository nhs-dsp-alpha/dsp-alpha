import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContentsListComponent } from './contents-list.component';

describe('ContentsListComponent', () => {
  let component: ContentsListComponent;
  let fixture: ComponentFixture<ContentsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContentsListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContentsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render', () => {
    fixture = TestBed.createComponent(ContentsListComponent);
    component = fixture.componentInstance;
    component.params = {
      items: [
        {
          href: "https://www.nhs.uk/conditions/age-related-macular-degeneration-amd/",
          text: "What is AMD?",
          current: true
        },
        {
          href: "https://www.nhs.uk/conditions/age-related-macular-degeneration-amd/symptoms/",
          text: "Symptoms"
        },
        {
          href: "https://www.nhs.uk/conditions/age-related-macular-degeneration-amd/getting-diagnosed/",
          text: "Getting diagnosed"
        }
        ,
        {
          href: "https://www.nhs.uk/conditions/age-related-macular-degeneration-amd/treatment/",
          text: "Treatments"
        }
        ,
        {
          href: "https://www.nhs.uk/conditions/age-related-macular-degeneration-amd/living-with-amd/",
          text: "Living with AMD"
        }
      ]
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });
});
