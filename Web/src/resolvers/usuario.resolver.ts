import { MensajeService } from "./../servicios/mensaje.service";
import { UsuarioService } from "./../servicios/usuario.service";
import { DetalleUsuario } from "./../model/DetalleUsuario";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Rx";
import "rxjs/add/operator/catch";

@Injectable()
export class UsuarioResolver implements Resolve<DetalleUsuario> {
  constructor(
    private usuarioService: UsuarioService,
    private router: Router,
    private mensajeService: MensajeService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<DetalleUsuario> {
    var usuario: DetalleUsuario = {} as DetalleUsuario;
    usuario.id = this.usuarioService.decodedToken.nameid;

    return this.usuarioService.obtenerUsuario(usuario).catch(error => {
      this.mensajeService.error("Problema al recibir la data");
      this.router.navigate(["/home"]);
      return Observable.of(null);
    });
  }
}
