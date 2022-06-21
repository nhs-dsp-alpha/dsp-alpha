import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrganisationConnectionsComponent } from './organisation-connections.component';

describe('OrganisationConnectionsComponent', () => {
  let component: OrganisationConnectionsComponent;
  let fixture: ComponentFixture<OrganisationConnectionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrganisationConnectionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrganisationConnectionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
