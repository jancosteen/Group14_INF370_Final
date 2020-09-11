import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReservationstatusCreateComponent } from './reservationstatus-create.component';

describe('ReservationstatusCreateComponent', () => {
  let component: ReservationstatusCreateComponent;
  let fixture: ComponentFixture<ReservationstatusCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReservationstatusCreateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReservationstatusCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
