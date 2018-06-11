import { ActualizarEquipo } from "./../../../model/ActualizarEquipo";
import { Component, OnInit, ViewChild } from "@angular/core";
import { FormGroup, NgForm, Validators, FormBuilder } from "@angular/forms";
import { EquipoService } from "../../../servicios/equipo.service";
import { MensajeService } from "../../../servicios/mensaje.service";
import { FileUploader } from "ng2-file-upload";
import { environment } from "../../../environments/environment";
import { ActivatedRoute } from "@angular/router";
import { GrupoService } from "../../../servicios/grupo.service";

@Component({
  selector: "app-editar-equipo",
  templateUrl: "./editar-equipo.component.html",
  styleUrls: ["./editar-equipo.component.css"]
})
export class EditarEquipoComponent implements OnInit {
  actualizaEquipo: FormGroup;
  localUrl: string;
  equipoModel: ActualizarEquipo = {} as ActualizarEquipo;
  @ViewChild("frmActualizaEquipo") frmActualizaEquipo: NgForm;
  idEquipo: number;
  listaGrupo: any[] = [] as any[];

  constructor(
    private fb: FormBuilder,
    private equipoService: EquipoService,
    public mensajeService: MensajeService,
    private route: ActivatedRoute,
    private grupoService: GrupoService
  ) {}

  ngOnInit() {
    this.obtnerEquipo();
    this.localUrl = "./assets/img/imgFondoBandera.jpg";
    this.inicializarFormulario();
    this.cargarGrupo();
  }

  cargarGrupo() {
    this.grupoService.listarGrupo().subscribe(
      grupo => {
        this.listaGrupo = grupo;
      },
      error => {
        this.mensajeService.error("Ocurrio un error interno");
      }
    );
  }

  obtnerEquipo() {
    this.idEquipo = this.route.snapshot.params["id"];

    this.equipoService.obtenerEquipo(this.idEquipo).subscribe(
      data => {
        this.equipoModel = data;
      },
      error => {
        this.mensajeService.error("Ocurrio un error interno ");
      },
      () => {
        this.inicializarFormulario();
        this.localUrl = this.equipoModel.banderaUrl;
      }
    );
  }

  inicializarFormulario() {
    this.actualizaEquipo = this.fb.group({
      Nombre: [
        this.equipoModel.nombre,
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(150)
        ]
      ],
      partidosJugados: [this.equipoModel.partidosJugados, Validators.required],
      partidosGanados: [this.equipoModel.partidosGanados, Validators.required],
      partidosEmpatados: [
        this.equipoModel.partidosEmpatados,
        Validators.required
      ],
      partidosPerdidos: [
        this.equipoModel.partidosPerdidos,
        Validators.required
      ],
      golesAFavor: [this.equipoModel.golesAFavor, Validators.required],
      golesEnContra: [this.equipoModel.golesEnContra, Validators.required],
      diferenciaGoles: [this.equipoModel.diferenciaGoles, Validators.required],
      puntos: [this.equipoModel.puntos, Validators.required],
      Grupo: [this.equipoModel.grupo, Validators.required]
    });
  }

  ActualizarEquipo() {
    if (this.actualizaEquipo.valid) {
      this.equipoModel = Object.assign({}, this.actualizaEquipo.value);

      this.equipoService
        .actualizarEquipo(this.idEquipo, this.equipoModel)
        .subscribe(
          equipo => {
            this.equipoModel = equipo;
            this.mensajeService.success("Registrado Correctamente ");
          },
          error => {
            this.mensajeService.error("Ocurrio un error interno");
          }
        );
    }
  }

  SeleccionarFoto(event) {
    if (event.target.files && event.target.files[0]) {
      var reader = new FileReader();
      reader.onload = (event: any) => {
        this.localUrl = event.target.result;
      };
      reader.readAsDataURL(event.target.files[0]);
    }
  }
}
