import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SharePassportSelectOrganisationComponent } from './share-passport-select-organisation.component';

describe('SharePassportSelectOrganisationComponent', () => {
  let component: SharePassportSelectOrganisationComponent;
  let fixture: ComponentFixture<SharePassportSelectOrganisationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SharePassportSelectOrganisationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SharePassportSelectOrganisationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
