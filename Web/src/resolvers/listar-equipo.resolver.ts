import { EquipoService } from "./../servicios/equipo.service";
import { Equipo } from "./../model/Equipo";
import { MensajeService } from "./../servicios/mensaje.service";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Rx";
import "rxjs/add/operator/catch";

@Injectable()
export class ListarEquipoResolver implements Resolve<Equipo[]> {
  constructor(
    private equipoService: EquipoService,
    private router: Router,
    private mensajeService: MensajeService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Equipo[]> {
    return this.equipoService.listarActivos().catch(error => {
      this.mensajeService.error("Problema al recibir la data");
      this.router.navigate(["/home"]);
      return Observable.of(null);
    });
  }
}
