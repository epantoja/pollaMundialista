/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ListarGrupoEquipoComponent } from './listar-grupoEquipo.component';

describe('ListarGrupoEquipoComponent', () => {
  let component: ListarGrupoEquipoComponent;
  let fixture: ComponentFixture<ListarGrupoEquipoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListarGrupoEquipoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListarGrupoEquipoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
