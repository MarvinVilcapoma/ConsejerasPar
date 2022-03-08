import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReferredNutritionistComponent } from './referred-nutritionist.component';

describe('ReferredNutritionistComponent', () => {
  let component: ReferredNutritionistComponent;
  let fixture: ComponentFixture<ReferredNutritionistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReferredNutritionistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReferredNutritionistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
