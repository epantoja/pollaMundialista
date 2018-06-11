import { FaseService } from "./../../../servicios/fase.service";
import { Component, OnInit } from "@angular/core";
import { Fase } from "../../../model/Fase";
import { MensajeService } from "../../../servicios/mensaje.service";
import { PorgramacionJuegoService } from "../../../servicios/porgramacionJuego.service";
import { ProgramacionJuegoLista } from "../../../model/ProgramacionJuegoLista";

@Component({
  selector: "app-listajuego",
  templateUrl: "./lista-juego.component.html",
  styleUrls: ["./lista-juego.component.css"]
})
export class ListaJuegoComponent implements OnInit {
  listaFase: Fase[] = [] as Fase[];
  listaProgramacionJuego: ProgramacionJuegoLista[] = [] as ProgramacionJuegoLista[];
  filtroProgramacionJuego: ProgramacionJuegoLista[] = [] as ProgramacionJuegoLista[];

  constructor(
    private faseService: FaseService,
    private mensajeService: MensajeService,
    private programacionJuegoService: PorgramacionJuegoService
  ) {}

  ngOnInit() {
    this.cargarListaProgramacionJuego();
  }

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

  cargarListaProgramacionJuego() {
    this.programacionJuegoService.listarTodos().subscribe(
      programacionJuego => {
        this.listaProgramacionJuego = programacionJuego;
      },
      error => {
        this.mensajeService.error("Ocurrio un error interno");
      },
      () => {
        this.cargarFases();
      }
    );
  }

  buscarJuego(event) {}

  listarJuegos(idFase) {
    this.filtroProgramacionJuego = [];

    this.filtroProgramacionJuego = this.listaProgramacionJuego.filter(
      x => x.fase.id == idFase
    );

    return this.filtroProgramacionJuego;
  }
}
