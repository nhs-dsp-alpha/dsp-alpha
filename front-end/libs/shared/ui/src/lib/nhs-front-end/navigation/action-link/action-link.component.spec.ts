import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActionLinkComponent } from './action-link.component';

describe('ActionLinkComponent', () => {
  let component: ActionLinkComponent;
  let fixture: ComponentFixture<ActionLinkComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActionLinkComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActionLinkComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render', () => {
    fixture = TestBed.createComponent(ActionLinkComponent);
    component = fixture.componentInstance;
    component.params = {
      "text": "Find a minor injuries unit",
      "href": "https://www.nhs.uk/service-search/minor-injuries-unit/locationsearch/551"
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });
});
