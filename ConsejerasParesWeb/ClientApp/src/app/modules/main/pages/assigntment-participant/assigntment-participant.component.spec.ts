import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssigntmentParticipantComponent } from './assigntment-participant.component';

describe('AssigntmentParticipantComponent', () => {
  let component: AssigntmentParticipantComponent;
  let fixture: ComponentFixture<AssigntmentParticipantComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AssigntmentParticipantComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AssigntmentParticipantComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
