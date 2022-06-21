import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoAndDontListComponent } from './do-and-dont-list.component';

describe('DoAndDontListComponent', () => {
  let component: DoAndDontListComponent;
  let fixture: ComponentFixture<DoAndDontListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DoAndDontListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DoAndDontListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render a do list', () => {
    fixture = TestBed.createComponent(DoAndDontListComponent);
    component = fixture.componentInstance;
    component.params = {
      "title": "Do",
      "type": "tick",
      "items": [
        {
          "item": "cover blisters that are likely to burst with a soft plaster or dressing"
        },
        {
          "item": "wash your hands before touching a burst blister"
        },
        {
          "item": "allow the fluid in a burst blister to drain before covering it with a plaster or dressing"
        }
      ]
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });

  it('should render a don\'t list', () => {
    fixture = TestBed.createComponent(DoAndDontListComponent);
    component = fixture.componentInstance;
    component.params = {
      "title": "Don't",
      "type": "cross",
      "items": [
        {
          "item": "burst a blister yourself"
        },
        {
          "item": "peel the skin off a burst blister"
        },
        {
          "item": "pick at the edges of the remaining skin"
        },
        {
          "item": "wear the shoes or use the equipment that caused your blister until it heals"
        }
      ]
    }
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });
});
