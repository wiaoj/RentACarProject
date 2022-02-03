import { TestBed } from '@angular/core/testing';

import { CarRentalService } from './car-rental.service';

describe('CarRentalService', () => {
  let service: CarRentalService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CarRentalService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
