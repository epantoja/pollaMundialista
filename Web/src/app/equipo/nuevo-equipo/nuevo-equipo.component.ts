import { MensajeService } from "./../../../servicios/mensaje.service";
import { EquipoService } from "./../../../servicios/equipo.service";
import { Equipo } from "./../../../model/Equipo";
import { Component, OnInit, ViewChild } from "@angular/core";
import { FormGroup, FormBuilder, Validators, NgForm } from "@angular/forms";
import { FileUploader } from "ng2-file-upload";
import { environment } from "../../../environments/environment";

const URL = environment.apiUrl + "Equipo/Guardar";

@Component({
  selector: "app-nuevo-equipo",
  templateUrl: "./nuevo-equipo.component.html",
  styleUrls: ["./nuevo-equipo.component.css"]
})
export class NuevoEquipoComponent implements OnInit {
  registroEquipo: FormGroup;
  localUrl: string;
  equipoModel: Equipo = {} as Equipo;
  @ViewChild("frmRegistrarEquipo") frmRegistrarEquipo: NgForm;

  uploader: FileUploader = new FileUploader({
    url: URL,
    authToken: "Bearer " + localStorage.getItem("token")
  });

  constructor(
    private fb: FormBuilder,
    private equipoService: EquipoService,
    public mensajeService: MensajeService
  ) {}

  ngOnInit() {
    this.inicializarFormulario();
    this.localUrl = "./assets/img/imgFondoBandera.jpg";
  }

  inicializarFormulario() {
    this.registroEquipo = this.fb.group({
      Nombre: [
        "",
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(150)
        ]
      ],
      File: ["", Validators.required]
    });
  }

  RegistrarEquipo() {
    if (this.registroEquipo.valid) {
      this.equipoModel = Object.assign({}, this.registroEquipo.value);

      this.uploader.options.additionalParameter = this.equipoModel;

      this.uploader.uploadAll();

      this.mensajeService.success("Registrado Correctamente ");

      this.localUrl = "./assets/img/imgFondoBandera.jpg";
      this.frmRegistrarEquipo.reset();
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
