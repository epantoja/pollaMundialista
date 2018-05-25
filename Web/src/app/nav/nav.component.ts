import { MensajeService } from "./../../servicios/mensaje.service";
import { UsuarioService } from "./../../servicios/usuario.service";
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: "app-nav",
  templateUrl: "./nav.component.html",
  styleUrls: ["./nav.component.css"]
})
export class NavComponent implements OnInit {

  constructor(
    private usuarioService: UsuarioService,
    private mensajeService: MensajeService,
    private router: Router
  ) {}

  ngOnInit() {}

  iniciadaSession() {
    return this.usuarioService.iniciadaSession();
  }

  logout() {
    this.usuarioService.userToken = null;
    localStorage.removeItem("token");
    this.mensajeService.message("Chao, vuelve pronto");
    this.router.navigate(["/home"]);
  }
}
