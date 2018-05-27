import { MensajeService } from "./../../../servicios/mensaje.service";
import { AuthAdminGuard } from "./../../../guards/authAdmin.guard";
import { Component, OnInit, ViewChild } from "@angular/core";
import { FormGroup, FormBuilder, Validators, NgForm } from "@angular/forms";
import { GrupoEquipo } from "../../../model/GrupoEquipo";
import { GrupoEquipoService } from "../../../servicios/grupoEquipo.service";

@Component({
  selector: "app-nuevo-grupoEquipo",
  templateUrl: "./nuevo-grupoEquipo.component.html",
  styleUrls: ["./nuevo-grupoEquipo.component.css"]
})
export class NuevoGrupoEquipoComponent implements OnInit {
  registroGrupoEquipo: FormGroup;
  equipoModel: GrupoEquipo = {} as GrupoEquipo;
  @ViewChild("frmRegistrarGrupoEquipo") frmRegistrarGrupoEquipo: NgForm;

  constructor(
    private fb: FormBuilder,
    private grupoEquipoService: GrupoEquipoService,
    private mensajeService: MensajeService
  ) {}

  ngOnInit() {
    this.inicializarFormulario();
  }

  inicializarFormulario() {
    this.registroGrupoEquipo = this.fb.group({
      Nombre: ["", Validators.required],
      Color: ["#ff0000", Validators.required],
      Orden: ["0", Validators.required]
    });
  }

  registrarGrupo() {
    if (this.registroGrupoEquipo.valid) {
      this.equipoModel = Object.assign({}, this.registroGrupoEquipo.value);

      this.grupoEquipoService.guardar(this.equipoModel).subscribe(
        () => {
          this.frmRegistrarGrupoEquipo.reset();
          this.mensajeService.success("Registrado Correctamente ");
        },
        error => {
          this.mensajeService.error("Ocurrio un error interno");
        }
      );
    }
  }
}
