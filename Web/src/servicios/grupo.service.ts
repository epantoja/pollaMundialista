import { Injectable } from "@angular/core";
import "rxjs/add/operator/map";
import "rxjs/add/operator/catch";
import "rxjs/add/observable/throw";
import { Observable } from "rxjs";
import { of } from "rxjs/observable/of";
import { delay } from "rxjs/operators";

export interface Grupo {
  nombre: string;
}

@Injectable()
export class GrupoService {
  constructor() {}

  listarGrupo(): Observable<Grupo[]> {
    let grupo = this.consultarGrupo();
    return of(grupo).pipe(delay(500));
  }

  private consultarGrupo() {
    return [
      { nombre: "Grupo A" },
      { nombre: "Grupo B" },
      { nombre: "Grupo C" },
      { nombre: "Grupo D" },
      { nombre: "Grupo E" },
      { nombre: "Grupo F" },
      { nombre: "Grupo G" },
      { nombre: "Grupo H" }
    ];
  }
}
