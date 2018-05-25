import { Equipo } from "./../model/Equipo";
import { Headers, RequestOptions, Response } from "@angular/http";
import { Injectable } from "@angular/core";
import "rxjs/add/operator/map";
import "rxjs/add/operator/catch";
import "rxjs/add/observable/throw";
import { Observable } from "rxjs/Observable";
import { environment } from "../environments/environment";
import { AuthHttp } from "angular2-jwt";
import { ActualizarEquipo } from "../model/ActualizarEquipo";

@Injectable()
export class EquipoService {
  baseUrl = environment.apiUrl + "Equipo/";

  constructor(private authHttp: AuthHttp) {}

  eliminarEquipo(Id: number): Observable<Equipo> {
    return this.authHttp
      .get(this.baseUrl + "Eliminar/" + Id)
      .catch(this.handlerError);
  }

  actualizarEquipo(
    Id: number,
    actualizarModel: ActualizarEquipo
  ): Observable<Equipo> {
    return this.authHttp
      .put(
        this.baseUrl + "Actualizar/" + Id,
        actualizarModel,
        this.requestOptions()
      )
      .map(response => <Equipo>response.json())
      .catch(this.handlerError);
  }

  listarActivos(): Observable<Equipo[]> {
    return this.authHttp
      .get(this.baseUrl + "Listar")
      .map(response => <Equipo[]>response.json())
      .catch(this.handlerError);
  }

  obtenerEquipo(id: number): Observable<ActualizarEquipo> {
    return this.authHttp
      .get(this.baseUrl + "Obtener/" + id)
      .map(response => <ActualizarEquipo>response.json())
      .catch(this.handlerError);
  }

  guardarEquipo(registroModel: Equipo) {
    return this.authHttp
      .post(this.baseUrl + "Guardar", registroModel, this.requestOptions())
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
