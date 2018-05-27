import { Component, OnInit, ViewChild } from "@angular/core";
import { FormBuilder, FormGroup, Validators, NgForm } from "@angular/forms";
import { GrupoEquipoService } from "../../../servicios/grupoEquipo.service";
import { MensajeService } from "../../../servicios/mensaje.service";
import { GrupoEquipo } from "../../../model/GrupoEquipo";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-editar-grupoEquipo",
  templateUrl: "./editar-grupoEquipo.component.html",
  styleUrls: ["./editar-grupoEquipo.component.css"]
})
export class EditarGrupoEquipoComponent implements OnInit {
  registroGrupoEquipo: FormGroup;
  equipoModel: GrupoEquipo = {} as GrupoEquipo;
  @ViewChild("frmRegistrarGrupoEquipo") frmRegistrarGrupoEquipo: NgForm;
  idGrupoEquipo: number;

  constructor(
    private fb: FormBuilder,
    private grupoEquipoService: GrupoEquipoService,
    private mensajeService: MensajeService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.inicializarFormulario();
    this.cargarGrupoEquipo();
  }

  inicializarFormulario() {
    this.registroGrupoEquipo = this.fb.group({
      Nombre: [this.equipoModel.nombre, Validators.required],
      Color: [this.equipoModel.color, Validators.required],
      Orden: [this.equipoModel.orden, Validators.required],
      Estado: [this.equipoModel.estado, Validators.required]
    });
  }

  cargarGrupoEquipo() {
    this.idGrupoEquipo = this.route.snapshot.params["id"];
    this.grupoEquipoService.obtener(this.idGrupoEquipo).subscribe(
      grupoEquipo => {
        this.equipoModel = grupoEquipo;
      },
      error => {
        this.mensajeService.error("Ocurrio un error interno");
      },
      () => {
        this.inicializarFormulario();
      }
    );
  }

  actualizarGrupo() {
    if (this.registroGrupoEquipo.valid) {
      this.equipoModel = Object.assign({}, this.registroGrupoEquipo.value);

      this.grupoEquipoService
        .actualizar(this.idGrupoEquipo, this.equipoModel)
        .subscribe(
          next => {
            this.frmRegistrarGrupoEquipo.reset(this.equipoModel);
            this.mensajeService.success("Actualizado correctamente");
          },
          error => {
            this.mensajeService.error("Ocurrio un error interno");
          }
        );
    }
  }
}
