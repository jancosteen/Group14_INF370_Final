import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpecialpriceListComponent } from './specialprice-list.component';

describe('SpecialpriceListComponent', () => {
  let component: SpecialpriceListComponent;
  let fixture: ComponentFixture<SpecialpriceListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpecialpriceListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpecialpriceListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
