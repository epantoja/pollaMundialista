import { Headers, RequestOptions, Response } from "@angular/http";
import { Injectable } from "@angular/core";
import "rxjs/add/operator/map";
import "rxjs/add/operator/catch";
import "rxjs/add/observable/throw";
import { Observable } from "rxjs/Observable";
import { environment } from "../environments/environment";
import { AuthHttp } from "angular2-jwt";
import { ProgramacionJuego } from "../model/ProgramacionJuego";
import { ProgramacionJuegoLista } from "../model/ProgramacionJuegoLista";

@Injectable()
export class PorgramacionJuegoService {
  baseUrl = environment.apiUrl + "ProgramacionJuego/";

  constructor(private authHttp: AuthHttp) {}

  listarTodos(): Observable<ProgramacionJuegoLista[]> {
    return this.authHttp
      .get(this.baseUrl + "ListarTodos")
      .map(response => <ProgramacionJuegoLista[]>response.json())
      .catch(this.handlerError);
  }

  guardar(programacionModel: ProgramacionJuego) {
    return this.authHttp
      .post(this.baseUrl + "Guardar", programacionModel)
      .catch(this.handlerError);
  }

  private requestOptions() {
    const headers = new Headers({ "Content-type": "application/json" });
    return new RequestOptions({ headers: headers });
  }

  private handlerError(error: any) {
    const applicationError = error.headers.get("Application-Error");
    if (applicationError) {
      return Observable.throw(applicationError);
    }
    const serverError = error.json();
    let modelStateError = "";
    if (serverError) {
      for (const key in serverError) {
        if (serverError[key]) {
          modelStateError += serverError[key] + "\n";
        }
      }
    }

    return Observable.throw(modelStateError || "Error del servidor");
  }
}
