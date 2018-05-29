import { MensajeService } from "./../../../servicios/mensaje.service";
import { AuthAdminGuard } from "./../../../guards/authAdmin.guard";
import { Component, OnInit, ViewChild } from "@angular/core";
import { FormGroup, FormBuilder, Validators, NgForm } from "@angular/forms";
import { Fase } from "../../../model/Fase";
import { FaseService } from "../../../servicios/fase.service";

@Component({
  selector: "app-nuevo-fase",
  templateUrl: "./nuevo-fase.component.html",
  styleUrls: ["./nuevo-fase.component.css"]
})
export class NuevoFaseComponent implements OnInit {
  registroFase: FormGroup;
  equipoModel: Fase = {} as Fase;
  @ViewChild("frmRegistrarFase") frmRegistrarFase: NgForm;

  constructor(
    private fb: FormBuilder,
    private faseService: FaseService,
    private mensajeService: MensajeService
  ) {}

  ngOnInit() {
    this.inicializarFormulario();
  }

  inicializarFormulario() {
    this.registroFase = this.fb.group({
      Nombre: ["", Validators.required],
      Color: ["#ff0000", Validators.required],
      Orden: ["0", Validators.required]
    });
  }

  registrarGrupo() {
    if (this.registroFase.valid) {
      this.equipoModel = Object.assign({}, this.registroFase.value);

      this.faseService.guardar(this.equipoModel).subscribe(
        () => {
          this.frmRegistrarFase.reset();
          this.mensajeService.success("Registrado Correctamente ");
        },
        error => {
          this.mensajeService.error("Ocurrio un error interno");
        }
      );
    }
  }
}
