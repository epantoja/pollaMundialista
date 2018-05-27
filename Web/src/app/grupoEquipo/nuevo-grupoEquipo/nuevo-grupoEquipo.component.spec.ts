/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { NuevoGrupoEquipoComponent } from './nuevo-grupoEquipo.component';

describe('NuevoGrupoEquipoComponent', () => {
  let component: NuevoGrupoEquipoComponent;
  let fixture: ComponentFixture<NuevoGrupoEquipoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NuevoGrupoEquipoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NuevoGrupoEquipoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
