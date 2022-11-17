import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayerProfileInfoComponent } from './player-profile-info.component';

describe('PlayerProfileInfoComponent', () => {
  let component: PlayerProfileInfoComponent;
  let fixture: ComponentFixture<PlayerProfileInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlayerProfileInfoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PlayerProfileInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
