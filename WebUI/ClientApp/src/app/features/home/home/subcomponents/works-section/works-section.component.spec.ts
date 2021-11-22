import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WorksSectionComponent } from './works-section.component';

describe('WorksSectionComponent', () => {
  let component: WorksSectionComponent;
  let fixture: ComponentFixture<WorksSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WorksSectionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WorksSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
