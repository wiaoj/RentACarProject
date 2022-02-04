import { TestBed } from '@angular/core/testing';

import { CarDetailByIdService } from './car-detailById.service';

describe('CarDetailByIdService', () => {
  let service: CarDetailByIdService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CarDetailByIdService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
