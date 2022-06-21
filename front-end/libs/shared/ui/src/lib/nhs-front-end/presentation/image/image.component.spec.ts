import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImageComponent } from './image.component';

describe('ImageComponent', () => {
  let component: ImageComponent;
  let fixture: ComponentFixture<ImageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ImageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render as expected', () => {
    fixture = TestBed.createComponent(ImageComponent);
    component = fixture.componentInstance;
    component.params = {
      "src": "https://assets.nhs.uk/prod/images/S_0318_Bullous_pemphigoid_lesions_.2e16d0ba.fill-320x213.jpg",
      "alt": "Lots of sore red patches with small blisters spread across white skin on a woman's chest.",
      "caption": "It can affect large areas of the body or limbs."
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });
});
