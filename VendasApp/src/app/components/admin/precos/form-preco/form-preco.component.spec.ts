import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormPrecoComponent } from './form-preco.component';

describe('FormPrecoComponent', () => {
  let component: FormPrecoComponent;
  let fixture: ComponentFixture<FormPrecoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormPrecoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormPrecoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
