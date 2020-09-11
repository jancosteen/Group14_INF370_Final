import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StocktakeDeleteComponent } from './stocktake-delete.component';

describe('StocktakeDeleteComponent', () => {
  let component: StocktakeDeleteComponent;
  let fixture: ComponentFixture<StocktakeDeleteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StocktakeDeleteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StocktakeDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
