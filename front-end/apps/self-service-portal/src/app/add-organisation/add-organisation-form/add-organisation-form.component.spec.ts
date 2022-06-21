import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddOrganisationFormComponent } from './add-organisation-form.component';

describe('AddOrganisationFormComponent', () => {
  let component: AddOrganisationFormComponent;
  let fixture: ComponentFixture<AddOrganisationFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddOrganisationFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddOrganisationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
