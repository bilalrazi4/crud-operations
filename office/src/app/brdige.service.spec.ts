import { TestBed } from '@angular/core/testing';

import { BrdigeService } from './brdige.service';

describe('BrdigeService', () => {
  let service: BrdigeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BrdigeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
