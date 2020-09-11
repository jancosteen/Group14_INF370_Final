import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StocktakeCreateComponent } from './stocktake-create.component';

describe('StocktakeCreateComponent', () => {
  let component: StocktakeCreateComponent;
  let fixture: ComponentFixture<StocktakeCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StocktakeCreateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StocktakeCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
