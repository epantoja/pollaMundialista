import { Fase } from "./../../model/Fase";
import { Component, OnInit, ChangeDetectionStrategy } from "@angular/core";
import { EquipoService } from "../../servicios/equipo.service";
import { Equipo } from "../../model/Equipo";
import { MensajeService } from "../../servicios/mensaje.service";
import { FaseService } from "../../servicios/fase.service";

@Component({
  selector: "app-juego",
  templateUrl: "./juego.component.html",
  styleUrls: ["./juego.component.css"]
})
export class JuegoComponent implements OnInit {
  listaEquipoA: Equipo[] = [] as Equipo[];
  listaEquipoB: Equipo[] = [] as Equipo[];
  listaEquipoTodos: Equipo[] = [] as Equipo[];
  listaFase: Fase[] = [] as Fase[];

  constructor(
    private equipoService: EquipoService,
    private mensajeService: MensajeService,
    private faseService: FaseService
  ) {}

  ngOnInit() {
    this.cargarEquipo();
    this.cargarFases();
    this.inciarFormulario();
  }

  inciarFormulario() {}

  cargarFases() {
    this.faseService.listar().subscribe(
      fase => {
        this.listaFase = fase;
      },
      error => {
        this.mensajeService.error("Ocurrio un error interno");
      }
    );
  }

  cargarEquipo() {
    this.equipoService.listarActivos().subscribe(
      equipo => {
        this.listaEquipoA = equipo;
        this.listaEquipoB = equipo;
        this.listaEquipoTodos = equipo;
      },
      error => {
        this.mensajeService.error("Ocurrio un error interno");
      }
    );
  }

  cambioEquipoA(event) {
    if (event != undefined) {
      this.listaEquipoB = [];
      this.listaEquipoB = this.listaEquipoTodos.filter(
        x => x.id != event["id"]
      );
    } else {
      this.listaEquipoB = this.listaEquipoTodos;
    }
  }

  cambioEquipoB(event) {
    if (event != undefined) {
      this.listaEquipoA = [];
      this.listaEquipoA = this.listaEquipoTodos.filter(
        x => x.id != event["id"]
      );
    } else {
      this.listaEquipoA = this.listaEquipoTodos;
    }
  }
}
