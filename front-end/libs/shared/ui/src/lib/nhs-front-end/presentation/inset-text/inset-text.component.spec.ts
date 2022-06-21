import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsetTextComponent } from './inset-text.component';

describe('InsetTextComponent', () => {
  let component: InsetTextComponent;
  let fixture: ComponentFixture<InsetTextComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InsetTextComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InsetTextComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render as expected', () => {
    fixture = TestBed.createComponent(InsetTextComponent);
    component = fixture.componentInstance;
    component.params = { 
      html: "<p>You can report any suspected side effect to the <a href=\"https://yellowcard.mhra.gov.uk/\" title=\"External website\">UK safety scheme</a>.</p>"
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });
});
