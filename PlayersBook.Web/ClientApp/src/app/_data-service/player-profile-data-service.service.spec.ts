import { TestBed } from '@angular/core/testing';

import { PlayerProfileDataServiceService } from '../_data-services/player-profile-data.service';

describe('PlayerProfileDataServiceService', () => {
  let service: PlayerProfileDataServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PlayerProfileDataServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
