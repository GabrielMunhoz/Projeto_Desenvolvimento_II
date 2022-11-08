import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AvaliateDialogComponent } from './avaliate-dialog.component';

describe('AvaliateDialogComponent', () => {
  let component: AvaliateDialogComponent;
  let fixture: ComponentFixture<AvaliateDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AvaliateDialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AvaliateDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
