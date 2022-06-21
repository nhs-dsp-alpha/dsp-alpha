import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AcceptCredentialComponent } from './accept-credential.component';

describe('AcceptCredentialComponent', () => {
  let component: AcceptCredentialComponent;
  let fixture: ComponentFixture<AcceptCredentialComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AcceptCredentialComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AcceptCredentialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
