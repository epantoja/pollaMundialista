import { MensajeService } from "./../../servicios/mensaje.service";
import { UsuarioService } from "./../../servicios/usuario.service";
import { Component, OnInit, TemplateRef } from "@angular/core";
import { GrupoUsuarioService } from "../../servicios/grupoUsuario.service";
import { GrupoUsuario } from "../../model/GrupoUsuario";
import { FormGroup, Validators, FormBuilder } from "@angular/forms";
import { Login } from "../../model/Login";
import { Router } from "@angular/router";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})
export class LoginComponent implements OnInit {
  listaGrupoUsuario: GrupoUsuario[] = [] as GrupoUsuario[];
  loginUsuario: FormGroup;
  mensaje: string;
  loginUsuarioModel: Login = {} as Login;

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
    this.loginUsuario = this.fb.group({
      CodUsuario: [
        "",
        [Validators.required, Validators.minLength(4), Validators.maxLength(15)]
      ],
      GrupoUsuarioId: ["", [Validators.required]],
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

  logueo() {
    if (this.loginUsuario.valid) {
      this.loginUsuarioModel = Object.assign({}, this.loginUsuario.value);

      this.usuarioService.login(this.loginUsuarioModel).subscribe(
        () => {
          this.mensajeService.success("Logueado Correctamente ");
        },
        error => {
          this.mensajeService.error("Ocurrio un error interno");
        },
        () => {
          /*
          this.inicioSessionService.login(this.registrarModel).subscribe(() => {
            this.router.navigate(["dashboard"]);
          });
          */
          this.router.navigate(["/home"]);
        }
      );
    }
  }
}
