import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StocktakeDetailsComponent } from './stocktake-details.component';

describe('StocktakeDetailsComponent', () => {
  let component: StocktakeDetailsComponent;
  let fixture: ComponentFixture<StocktakeDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StocktakeDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StocktakeDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
