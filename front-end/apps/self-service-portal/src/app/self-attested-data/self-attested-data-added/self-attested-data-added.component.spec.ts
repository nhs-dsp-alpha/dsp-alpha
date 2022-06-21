import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelfAttestedDataAddedComponent } from './self-attested-data-added.component';

describe('SelfAttestedDataAddedComponent', () => {
  let component: SelfAttestedDataAddedComponent;
  let fixture: ComponentFixture<SelfAttestedDataAddedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SelfAttestedDataAddedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SelfAttestedDataAddedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
