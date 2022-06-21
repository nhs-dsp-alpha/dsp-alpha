import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SkipLinkComponent } from './skip-link.component';

describe('SkipLinkComponent', () => {
  let component: SkipLinkComponent;
  let fixture: ComponentFixture<SkipLinkComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SkipLinkComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SkipLinkComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render', () => {
    fixture = TestBed.createComponent(SkipLinkComponent);
    component = fixture.componentInstance;
    component.params = {
      "href": "#maincontent",
      "text": "Skip to main content"
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });
});
