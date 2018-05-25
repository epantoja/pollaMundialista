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
export class LoginGuard implements CanActivate {
  constructor(
    private usuarioService: UsuarioService,
    private router: Router,
    private mensajeService: MensajeService
  ) {}

  canActivate(): Observable<boolean> | Promise<boolean> | boolean {
    if (!this.usuarioService.iniciadaSession()) {
      return true;
    }
    this.router.navigate(["/home"]);
    return false;
  }
}
