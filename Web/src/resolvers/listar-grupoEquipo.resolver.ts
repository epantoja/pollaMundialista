import { MensajeService } from "./../servicios/mensaje.service";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Rx";
import "rxjs/add/operator/catch";
import { GrupoEquipo } from "../model/GrupoEquipo";
import { GrupoEquipoService } from "../servicios/grupoEquipo.service";

@Injectable()
export class ListarGrupoEquipoResolver implements Resolve<GrupoEquipo[]> {
  constructor(
    private grupoEquipoService: GrupoEquipoService,
    private router: Router,
    private mensajeService: MensajeService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<GrupoEquipo[]> {
    return this.grupoEquipoService.listarTodos().catch(error => {
      this.mensajeService.error("Problema al recibir la data");
      this.router.navigate(["/home"]);
      return Observable.of(null);
    });
  }
}
