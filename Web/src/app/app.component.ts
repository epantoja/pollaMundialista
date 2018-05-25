import { UsuarioService } from './../servicios/usuario.service';
import { Component } from '@angular/core';
import { JwtHelper } from 'angular2-jwt';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  jwtHelper: JwtHelper = new JwtHelper();
  
  constructor(private usuarioService: UsuarioService){
    const token = localStorage.getItem("token");
    if (token) {
      this.usuarioService.decodedToken = this.jwtHelper.decodeToken(
        token
      );
    }
  }
}
