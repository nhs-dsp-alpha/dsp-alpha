import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelfAttestedDataComponent } from './self-attested-data.component';

describe('SelfAttestedDataComponent', () => {
  let component: SelfAttestedDataComponent;
  let fixture: ComponentFixture<SelfAttestedDataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SelfAttestedDataComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SelfAttestedDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
