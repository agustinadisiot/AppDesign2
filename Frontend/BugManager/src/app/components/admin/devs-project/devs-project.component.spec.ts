import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DevsProjectComponent } from './devs-project.component';

describe('DevsProjectComponent', () => {
  let component: DevsProjectComponent;
  let fixture: ComponentFixture<DevsProjectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DevsProjectComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DevsProjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
