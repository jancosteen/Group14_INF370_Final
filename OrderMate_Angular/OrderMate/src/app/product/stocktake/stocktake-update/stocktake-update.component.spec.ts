import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StocktakeUpdateComponent } from './stocktake-update.component';

describe('StocktakeUpdateComponent', () => {
  let component: StocktakeUpdateComponent;
  let fixture: ComponentFixture<StocktakeUpdateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StocktakeUpdateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StocktakeUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
