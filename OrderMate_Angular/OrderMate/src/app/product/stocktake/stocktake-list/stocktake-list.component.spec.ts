import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StocktakeListComponent } from './stocktake-list.component';

describe('StocktakeListComponent', () => {
  let component: StocktakeListComponent;
  let fixture: ComponentFixture<StocktakeListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StocktakeListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StocktakeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
