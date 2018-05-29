import { MensajeService } from "./../servicios/mensaje.service";
import { Resolve, Router, ActivatedRouteSnapshot } from "@angular/router";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Rx";
import "rxjs/add/operator/catch";
import { Fase } from "../model/Fase";
import { FaseService } from "../servicios/fase.service";

@Injectable()
export class ListarFaseResolver implements Resolve<Fase[]> {
  constructor(
    private faseService: FaseService,
    private router: Router,
    private mensajeService: MensajeService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Fase[]> {
    return this.faseService.listarTodos().catch(error => {
      this.mensajeService.error("Problema al recibir la data");
      this.router.navigate(["/home"]);
      return Observable.of(null);
    });
  }
}
