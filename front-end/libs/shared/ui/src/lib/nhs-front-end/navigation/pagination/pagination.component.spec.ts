import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaginationComponent } from './pagination.component';

describe('PaginationComponent', () => {
  let component: PaginationComponent;
  let fixture: ComponentFixture<PaginationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PaginationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PaginationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render', () => {
    fixture = TestBed.createComponent(PaginationComponent);
    component = fixture.componentInstance;
    component.params = {
      "previousUrl": "#",
      "previousPage": "Treatments",
      "nextUrl": "#",
      "nextPage": "Symptoms"
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });
});
