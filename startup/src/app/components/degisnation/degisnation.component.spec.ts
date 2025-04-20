import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DegisnationComponent } from './degisnation.component';

describe('DegisnationComponent', () => {
  let component: DegisnationComponent;
  let fixture: ComponentFixture<DegisnationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DegisnationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DegisnationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});