import { Headers, RequestOptions, Response } from "@angular/http";
import { Injectable } from "@angular/core";
import "rxjs/add/operator/map";
import "rxjs/add/operator/catch";
import "rxjs/add/observable/throw";
import { Observable } from "rxjs/Observable";
import { environment } from "../environments/environment";
import { Fase } from "../model/Fase";
import { AuthHttp } from "angular2-jwt";

@Injectable()
export class FaseService {
  baseUrl = environment.apiUrl + "Fase/";

  constructor(private authHttp: AuthHttp) {}

  listar(): Observable<Fase[]> {
    return this.authHttp
      .get(this.baseUrl + "Listar")
      .map(response => <Fase[]>response.json())
      .catch(this.handlerError);
  }

  listarTodos(): Observable<Fase[]> {
    return this.authHttp
      .get(this.baseUrl + "ListarTodos")
      .map(response => <Fase[]>response.json())
      .catch(this.handlerError);
  }

  guardar(grupoEquipoModel: Fase) {
    return this.authHttp
      .post(this.baseUrl + "Guardar", grupoEquipoModel)
      .catch(this.handlerError);
  }

  eliminar(id: number): Observable<Fase[]> {
    return this.authHttp
      .get(this.baseUrl + "Eliminar/" + id)
      .map(response => <Fase[]>response.json())
      .catch(this.handlerError);
  }

  obtener(id: number): Observable<Fase> {
    return this.authHttp
      .get(this.baseUrl + "Obtener/" + id)
      .map(response => <Fase>response.json())
      .catch(this.handlerError);
  }

  actualizar(
    id: number,
    grupoEquipoModel: Fase
  ): Observable<Fase> {
    return this.authHttp
      .put(this.baseUrl + "Actualizar/" + id, grupoEquipoModel)
      .map(response => <Fase>response.json())
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
