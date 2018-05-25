import { DetalleUsuario } from "./../../model/DetalleUsuario";
import { Component, OnInit, ViewChild } from "@angular/core";
import { GrupoUsuario } from "../../model/GrupoUsuario";
import { FormGroup, FormBuilder, Validators, NgForm } from "@angular/forms";
import { RegistrarUsuario } from "../../model/RegistrarUsuario";
import { GrupoUsuarioService } from "../../servicios/grupoUsuario.service";
import { UsuarioService } from "../../servicios/usuario.service";
import { MensajeService } from "../../servicios/mensaje.service";
import { ActivatedRoute } from "@angular/router";
import { ActualizarClave } from "../../model/ActualizarClave";

@Component({
  selector: "app-perfil",
  templateUrl: "./perfil.component.html",
  styleUrls: ["./perfil.component.css"]
})
export class PerfilComponent implements OnInit {
  listaGrupoUsuario: GrupoUsuario[] = [] as GrupoUsuario[];
  registroUsuario: FormGroup;
  cambioClave: FormGroup;
  mensaje: string;
  usuarioDetalle: DetalleUsuario = {} as DetalleUsuario;
  actualizarUsuarioModel: RegistrarUsuario = {} as RegistrarUsuario;
  actualizarClave: ActualizarClave = {} as ActualizarClave;
  @ViewChild("frmActualizarUsuario") frmActualizarUsuario: NgForm;
  @ViewChild("frmCambioClave") frmCambioClave: NgForm;

  constructor(
    private grupoUsuarioService: GrupoUsuarioService,
    private fb: FormBuilder,
    private usuarioService: UsuarioService,
    private route: ActivatedRoute,
    private mensajeService: MensajeService
  ) {}

  ngOnInit() {
    this.obtenerUsuario();
    this.cargarGrupoUsuario();
    this.inicializarFormulario();
    this.inicializarFormularioClave();
  }

  obtenerUsuario() {
    this.route.data.subscribe(data => {
      this.usuarioDetalle = data["usuarioDetalle"];
    });
  }

  inicializarFormulario() {
    this.registroUsuario = this.fb.group({
      CodUsuario: [
        this.usuarioDetalle.codUsuario,
        [Validators.required, Validators.minLength(4), Validators.maxLength(15)]
      ],
      GrupoActual: [
        this.usuarioDetalle.grupoActual.nombre,
        [Validators.required]
      ],
      Nombres: [
        this.usuarioDetalle.nombres,
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(150)
        ]
      ]
    });
  }

  inicializarFormularioClave() {
    this.cambioClave = this.fb.group(
      {
        Contrasena: [
          "",
          [
            Validators.required,
            Validators.minLength(4),
            Validators.maxLength(15)
          ]
        ],
        ContrasenaNueva: [
          "",
          [
            Validators.required,
            Validators.minLength(4),
            Validators.maxLength(15)
          ]
        ],
        ConfirmarContrasena: [
          "",
          [
            Validators.required,
            Validators.minLength(4),
            Validators.maxLength(15)
          ]
        ]
      },
      this.confirmarContrasenaIgual
    );
  }

  confirmarContrasenaIgual(g: FormGroup) {
    return g.get("ClaveNueva").value === g.get("ConfirmarClaveNueva").value
      ? null
      : { mismatch: true };
  }

  cargarGrupoUsuario() {
    this.grupoUsuarioService.listarActivos().subscribe(
      grupoUsuario => {
        this.listaGrupoUsuario = grupoUsuario;
      },
      error => {
        console.log(error);
      }
    );
  }

  modificarUsuario() {
    if (this.registroUsuario.valid) {
      this.actualizarUsuarioModel = Object.assign(
        {},
        this.registroUsuario.value
      );

      this.usuarioService
        .actualizar(
          this.usuarioService.decodedToken.nameid,
          this.actualizarUsuarioModel
        )
        .subscribe(
          () => {
            this.mensajeService.success("Actualizado Correctamente");
            this.frmActualizarUsuario.reset(this.actualizarUsuarioModel);
          },
          error => {
            this.mensajeService.error("Ocurrio un error interno");
          }
        );
    }
  }

  modificarClaveUsuario() {
    if (this.cambioClave.valid) {
      this.actualizarClave = Object.assign({}, this.cambioClave.value);

      this.usuarioService
        .actualizarClave(
          this.usuarioService.decodedToken.nameid,
          this.actualizarClave
        )
        .subscribe(
          () => {
            this.mensajeService.success("Clave Actualizada Correctamente");
            this.frmCambioClave.reset();
          },
          error => {
            this.mensajeService.error("Ocurrio un error interno");
          }
        );
    }
  }
}
