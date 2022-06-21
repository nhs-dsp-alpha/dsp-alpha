import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IssueVerifyComponent } from './issue-verify.component';

describe('IssueVerifyComponent', () => {
  let component: IssueVerifyComponent;
  let fixture: ComponentFixture<IssueVerifyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IssueVerifyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IssueVerifyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
