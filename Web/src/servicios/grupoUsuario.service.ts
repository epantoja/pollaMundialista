import { Http, Headers, RequestOptions, Response } from "@angular/http";
import { Injectable } from "@angular/core";
import "rxjs/add/operator/map";
import "rxjs/add/operator/catch";
import "rxjs/add/observable/throw";
import { Observable } from "rxjs/Observable";
import { environment } from "../environments/environment";
import { GrupoUsuario } from "../model/GrupoUsuario";


@Injectable()
export class GrupoUsuarioService {
  baseUrl = environment.apiUrl + "GrupoUsuario/";

  constructor(private http: Http) {}

  listarActivos(): Observable<GrupoUsuario[]> {
    return this.http
      .get(this.baseUrl + "Listar")
      .map(response => <GrupoUsuario[]>response.json())
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
