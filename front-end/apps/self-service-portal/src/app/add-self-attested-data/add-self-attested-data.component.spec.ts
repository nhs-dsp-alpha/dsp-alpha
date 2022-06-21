import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddSelfAttestedDataComponent } from './add-self-attested-data.component';

describe('AddSelfAttestedDataComponent', () => {
  let component: AddSelfAttestedDataComponent;
  let fixture: ComponentFixture<AddSelfAttestedDataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddSelfAttestedDataComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddSelfAttestedDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
