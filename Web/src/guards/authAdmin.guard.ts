import { MensajeService } from "./../servicios/mensaje.service";
import { Router } from "@angular/router";
import { Injectable } from "@angular/core";
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot
} from "@angular/router";
import { Observable } from "rxjs/Observable";
import { UsuarioService } from "../servicios/usuario.service";

@Injectable()
export class AuthAdminGuard implements CanActivate {
  constructor(
    private usuarioService: UsuarioService,
    private router: Router,
    private mensajeService: MensajeService
  ) {}

  canActivate(): Observable<boolean> | Promise<boolean> | boolean {
    if (
      this.usuarioService.iniciadaSession() &&
      this.usuarioService.decodedToken.role == 1
    ) {
      return true;
    }

    this.mensajeService.error("Ooouucchh, necesitar ser administrador");
    this.router.navigate(["/home"]);
    return false;
  }
}
