import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HistForecastComponent } from './hist-forecast.component';

describe('HistForecastComponent', () => {
  let component: HistForecastComponent;
  let fixture: ComponentFixture<HistForecastComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HistForecastComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HistForecastComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
