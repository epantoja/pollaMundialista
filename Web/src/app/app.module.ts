import { EditarEquipoResolver } from './../resolvers/editar-equipo.resolver';
import { EditarEquipoComponent } from "./equipo/editar-equipo/editar-equipo.component";
import { FileUploadModule } from "ng2-file-upload";
import { EquipoService } from "./../servicios/equipo.service";
import { CardEquipoComponent } from "./equipo/card-equipo/card-equipo.component";
import { ListarEquipoComponent } from "./equipo/listar-equipo/listar-equipo.component";
import { UsuarioResolver } from "./../resolvers/usuario.resolver";
import { AuthAdminGuard } from "./../guards/authAdmin.guard";
import { LoginGuard } from "./../guards/login.guard";
import { MensajeService } from "./../servicios/mensaje.service";
import { UsuarioService } from "./../servicios/usuario.service";
import { LoginComponent } from "./login/login.component";
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { appRoutes } from "./routes";

import { AppComponent } from "./app.component";
import { NavComponent } from "./nav/nav.component";
import { HomeComponent } from "./home/home.component";
import { RouterModule } from "@angular/router";

import { HttpModule } from "@angular/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { GrupoUsuarioService } from "../servicios/grupoUsuario.service";
import { RegistrarComponent } from "./registrar/registrar.component";

import { ModalModule, TabsModule } from "ngx-bootstrap";
import { BsDropdownModule } from "ngx-bootstrap";
import { GrupoEquipoComponent } from "./grupoEquipo/grupoEquipo.component";
import { JuegoComponent } from "./juego/juego.component";
import { UsuarioComponent } from "./usuario/usuario.component";
import { GrupoUsuarioComponent } from "./grupoUsuario/grupoUsuario.component";
import { AuthGuard } from "../guards/auth.guard";
import { PerfilComponent } from "./perfil/perfil.component";
import { AuthModule } from "./auth/auth.module";
import { ListarEquipoResolver } from "../resolvers/listar-equipo.resolver";
import { NuevoEquipoComponent } from "./equipo/nuevo-equipo/nuevo-equipo.component";

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    LoginComponent,
    HomeComponent,
    RegistrarComponent,
    ListarEquipoComponent,
    GrupoEquipoComponent,
    JuegoComponent,
    UsuarioComponent,
    GrupoUsuarioComponent,
    PerfilComponent,
    CardEquipoComponent,
    NuevoEquipoComponent,
    EditarEquipoComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule,
    AuthModule,
    RouterModule.forRoot(appRoutes),
    ModalModule.forRoot(),
    BsDropdownModule.forRoot(),
    TabsModule.forRoot(),
    ReactiveFormsModule,
    FileUploadModule
  ],
  providers: [
    GrupoUsuarioService,
    UsuarioService,
    MensajeService,
    AuthGuard,
    LoginGuard,
    AuthAdminGuard,
    UsuarioResolver,
    ListarEquipoResolver,
    EquipoService,
    EditarEquipoResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
