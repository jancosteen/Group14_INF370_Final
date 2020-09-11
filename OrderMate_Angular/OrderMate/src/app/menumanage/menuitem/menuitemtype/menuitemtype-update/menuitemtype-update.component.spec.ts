import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuitemtypeUpdateComponent } from './menuitemtype-update.component';

describe('MenuitemtypeUpdateComponent', () => {
  let component: MenuitemtypeUpdateComponent;
  let fixture: ComponentFixture<MenuitemtypeUpdateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MenuitemtypeUpdateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MenuitemtypeUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
