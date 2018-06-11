import { PorgramacionJuegoService } from "./../../../servicios/porgramacionJuego.service";
import { ProgramacionJuego } from "./../../../model/ProgramacionJuego";
import { Component, OnInit, ViewChild } from "@angular/core";
import { Equipo } from "../../../model/Equipo";
import { Fase } from "../../../model/Fase";
import { EquipoService } from "../../../servicios/equipo.service";
import { MensajeService } from "../../../servicios/mensaje.service";
import { FaseService } from "../../../servicios/fase.service";
import { FormGroup, FormBuilder, Validators, NgForm } from "@angular/forms";

@Component({
  selector: "app-nuevo-juego",
  templateUrl: "./nuevo-juego.component.html",
  styleUrls: ["./nuevo-juego.component.css"]
})
export class NuevoJuegoComponent implements OnInit {
  listaEquipoA: Equipo[] = [] as Equipo[];
  listaEquipoB: Equipo[] = [] as Equipo[];
  listaEquipoTodos: Equipo[] = [] as Equipo[];
  listaFase: Fase[] = [] as Fase[];
  registroJuego: FormGroup;
  programacionJuego: ProgramacionJuego = {} as ProgramacionJuego;
  @ViewChild("frmRegistrarJuego") frmRegistrarJuego: NgForm;

  constructor(
    private equipoService: EquipoService,
    private mensajeService: MensajeService,
    private faseService: FaseService,
    private programacionJuegoService: PorgramacionJuegoService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.cargarEquipo();
    this.cargarFases();
    this.inciarFormulario();
  }

  inciarFormulario() {
    this.registroJuego = this.fb.group({
      FaseId: [null, Validators.required],
      equipoAId: [null, Validators.required],
      equipoBId: [null, Validators.required],
      fechaJuego: [null, Validators.required],
      Orden: [null, Validators.required]
    });
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

  registrarProgramacionJuego() {
    if (this.registroJuego.valid) {
      this.programacionJuego = Object.assign({}, this.registroJuego.value);

      this.programacionJuegoService.guardar(this.programacionJuego).subscribe(
        () => {
          this.frmRegistrarJuego.reset();
          this.mensajeService.success("Registrado Correctamente ");
        },
        error => {
          this.mensajeService.error("Ocurrio un error interno");
        }
      );
    }
  }
}
