import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DepartementsListComponent } from './departements-list.component';

describe('DepartementsListComponent', () => {
  let component: DepartementsListComponent;
  let fixture: ComponentFixture<DepartementsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DepartementsListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DepartementsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
