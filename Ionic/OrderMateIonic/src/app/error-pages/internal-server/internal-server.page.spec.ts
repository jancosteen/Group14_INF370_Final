import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { InternalServerPage } from './internal-server.page';

describe('InternalServerPage', () => {
  let component: InternalServerPage;
  let fixture: ComponentFixture<InternalServerPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InternalServerPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(InternalServerPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
