import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalAddComponent } from './car-rental-add.component';

describe('CarRentalAddComponent', () => {
  let component: CarRentalAddComponent;
  let fixture: ComponentFixture<CarRentalAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarRentalAddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CarRentalAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
