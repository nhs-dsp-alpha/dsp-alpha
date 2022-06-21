import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FindOrganisationComponent } from './find-organisation.component';

describe('FindOrganisationComponent', () => {
  let component: FindOrganisationComponent;
  let fixture: ComponentFixture<FindOrganisationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FindOrganisationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FindOrganisationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
