import { Component, OnInit, ViewChild } from "@angular/core";
import { FormBuilder, FormGroup, Validators, NgForm } from "@angular/forms";
import { FaseService } from "../../../servicios/fase.service";
import { MensajeService } from "../../../servicios/mensaje.service";
import { Fase } from "../../../model/Fase";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-editar-fase",
  templateUrl: "./editar-fase.component.html",
  styleUrls: ["./editar-fase.component.css"]
})
export class EditarFaseComponent implements OnInit {
  registroFase: FormGroup;
  equipoModel: Fase = {} as Fase;
  @ViewChild("frmRegistrarFase") frmRegistrarFase: NgForm;
  idFase: number;

  constructor(
    private fb: FormBuilder,
    private faseService: FaseService,
    private mensajeService: MensajeService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.inicializarFormulario();
    this.cargarFase();
  }

  inicializarFormulario() {
    this.registroFase = this.fb.group({
      Nombre: [this.equipoModel.nombre, Validators.required],
      Color: [this.equipoModel.color, Validators.required],
      Orden: [this.equipoModel.orden, Validators.required],
      Estado: [this.equipoModel.estado, Validators.required]
    });
  }

  cargarFase() {
    this.idFase = this.route.snapshot.params["id"];
    this.faseService.obtener(this.idFase).subscribe(
      fase => {
        this.equipoModel = fase;
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
    if (this.registroFase.valid) {
      this.equipoModel = Object.assign({}, this.registroFase.value);

      this.faseService
        .actualizar(this.idFase, this.equipoModel)
        .subscribe(
          next => {
            this.frmRegistrarFase.reset(this.equipoModel);
            this.mensajeService.success("Actualizado correctamente");
          },
          error => {
            this.mensajeService.error("Ocurrio un error interno");
          }
        );
    }
  }
}
