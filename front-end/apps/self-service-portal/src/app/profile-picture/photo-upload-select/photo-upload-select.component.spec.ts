import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PhotoUploadSelectComponent } from './photo-upload-select.component';

describe('PhotoUploadSelectComponent', () => {
  let component: PhotoUploadSelectComponent;
  let fixture: ComponentFixture<PhotoUploadSelectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PhotoUploadSelectComponent],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PhotoUploadSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
