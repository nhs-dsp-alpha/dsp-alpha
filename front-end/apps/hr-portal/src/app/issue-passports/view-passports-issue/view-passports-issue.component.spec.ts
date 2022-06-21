import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewPassportsIssueComponent } from './view-passports-issue.component';

describe('ViewPassportsIssueComponent', () => {
  let component: ViewPassportsIssueComponent;
  let fixture: ComponentFixture<ViewPassportsIssueComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewPassportsIssueComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewPassportsIssueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
