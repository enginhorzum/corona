import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CoronaTestFormComponent } from './corona-test-form.component';

describe('CoronaTestFormComponent', () => {
  let component: CoronaTestFormComponent;
  let fixture: ComponentFixture<CoronaTestFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CoronaTestFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CoronaTestFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
