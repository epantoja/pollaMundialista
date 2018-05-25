import { ActualizarClave } from "./../model/ActualizarClave";
import { DetalleUsuario } from "./../model/DetalleUsuario";
import { Http, Headers, RequestOptions, Response } from "@angular/http";
import { Injectable } from "@angular/core";
import "rxjs/add/operator/map";
import "rxjs/add/operator/catch";
import "rxjs/add/observable/throw";
import { Observable } from "rxjs/Observable";
import { environment } from "../environments/environment";
import { Login } from "../model/Login";
import { tokenNotExpired, JwtHelper, AuthHttp } from "angular2-jwt";
import { RegistrarUsuario } from "../model/RegistrarUsuario";

@Injectable()
export class UsuarioService {
  baseUrl = environment.apiUrl + "Usuario/";
  userToken: any;
  decodedToken: any;
  jwtHelper: JwtHelper = new JwtHelper();

  constructor(private http: Http, private authHttp: AuthHttp) {}

  obtenerUsuario(usuario: DetalleUsuario): Observable<DetalleUsuario> {
    return this.authHttp
      .post(this.baseUrl + "Obtener", usuario, this.requestOptions())
      .map(response => <DetalleUsuario>response.json())
      .catch(this.handlerError);
  }

  actualizarClave(id: number, registroModel: ActualizarClave) {
    return this.authHttp
      .put(this.baseUrl + "ActualizarClave/" + id, registroModel)
      .catch(this.handlerError);
  }

  actualizar(id: number, registroModel: RegistrarUsuario) {
    return this.authHttp
      .put(this.baseUrl + "ActualizarUsuario/" + id, registroModel)
      .catch(this.handlerError);
  }

  registrar(registroModel: RegistrarUsuario) {
    return this.http
      .post(this.baseUrl + "register", registroModel, this.requestOptions())
      .catch(this.handlerError);
  }

  login(loginModel: Login) {
    return this.http
      .post(this.baseUrl + "login", loginModel, this.requestOptions())
      .map((response: Response) => {
        const user = response.json();
        if (user) {
          localStorage.setItem("token", user.tokenString);
          this.decodedToken = this.jwtHelper.decodeToken(user.tokenString);
          this.userToken = user.tokenString;
        }
      })
      .catch(this.handlerError);
  }

  iniciadaSession() {
    return tokenNotExpired("token");
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
