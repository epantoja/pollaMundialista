import { ActualizarEquipo } from "./../model/ActualizarEquipo";
import { EquipoService } from "./../servicios/equipo.service";
import { MensajeService } from "./../servicios/mensaje.service";
import {
  Resolve,
  Router,
  ActivatedRouteSnapshot,
  ActivatedRoute
} from "@angular/router";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Rx";
import "rxjs/add/operator/catch";

@Injectable()
export class EditarEquipoResolver implements Resolve<ActualizarEquipo[]> {
  constructor(
    private equipoService: EquipoService,
    private router: Router,
    private mensajeService: MensajeService,
    private route: ActivatedRoute
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<ActualizarEquipo[]> {
    var idEquipo = this.route.snapshot.params["id"];

    return this.equipoService.obtenerEquipo(idEquipo).catch(error => {
      this.mensajeService.error("Problema al recibir la data");
      this.router.navigate(["/home"]);
      return Observable.of(null);
    });
  }
}
