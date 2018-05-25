import { Component, OnInit } from "@angular/core";
import { GrupoUsuarioService } from "../../servicios/grupoUsuario.service";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { UsuarioService } from "../../servicios/usuario.service";
import { MensajeService } from "../../servicios/mensaje.service";
import { Router } from "@angular/router";
import { GrupoUsuario } from "../../model/GrupoUsuario";
import { RegistrarUsuario } from "../../model/RegistrarUsuario";

@Component({
  selector: "app-registrar",
  templateUrl: "./registrar.component.html",
  styleUrls: ["./registrar.component.css"]
})
export class RegistrarComponent implements OnInit {
  listaGrupoUsuario: GrupoUsuario[] = [] as GrupoUsuario[];
  registroUsuario: FormGroup;
  mensaje: string;
  registroUsuarioModel: RegistrarUsuario = {} as RegistrarUsuario;

  constructor(
    private grupoUsuarioService: GrupoUsuarioService,
    private fb: FormBuilder,
    private usuarioService: UsuarioService,
    private mensajeService: MensajeService,
    private router: Router
  ) {}

  ngOnInit() {
    this.cargarGrupoUsuario();
    this.inicializarFormulario();
  }

  inicializarFormulario() {
    this.registroUsuario = this.fb.group({
      CodUsuario: [
        "",
        [Validators.required, Validators.minLength(4), Validators.maxLength(15)]
      ],
      GrupoUsuarioId: ["", [Validators.required]],
      Nombres: [
        "",
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(150)
        ]
      ],
      Contrasena: [
        "",
        [Validators.required, Validators.minLength(4), Validators.maxLength(15)]
      ]
    });
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

  registrar() {
    if (this.registroUsuario.valid) {
      this.registroUsuarioModel = Object.assign({}, this.registroUsuario.value);

      this.usuarioService.registrar(this.registroUsuarioModel).subscribe(
        () => {
          this.mensajeService.success("Registrado Correctamente ");
        },
        error => {
          this.mensajeService.error(error);
        },
        () => {
          this.usuarioService.login(this.registroUsuarioModel).subscribe(() => {
            this.router.navigate(["/home"]);
          });
        }
      );
    }
  }
}
