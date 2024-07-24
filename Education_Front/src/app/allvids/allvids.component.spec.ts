import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllvidsComponent } from './allvids.component';

describe('AllvidsComponent', () => {
  let component: AllvidsComponent;
  let fixture: ComponentFixture<AllvidsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AllvidsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllvidsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
