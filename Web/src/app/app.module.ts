import { GrupoService } from "./../servicios/grupo.service";
import { NgSelectModule } from "@ng-select/ng-select";
import { EditarFaseComponent } from "./fase/editar-fase/editar-fase.component";
import { FaseService } from "./../servicios/fase.service";
import { CambiosPendientesPerfil } from "./../guards/cambiosPendientesPerfil.guard";
import { ListarFaseComponent } from "./fase/listar-fase/listar-fase.component";
import { EditarEquipoResolver } from "./../resolvers/editar-equipo.resolver";
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
import { JuegoComponent } from "./juego/juego.component";
import { UsuarioComponent } from "./usuario/usuario.component";
import { GrupoUsuarioComponent } from "./grupoUsuario/grupoUsuario.component";
import { AuthGuard } from "../guards/auth.guard";
import { PerfilComponent } from "./perfil/perfil.component";
import { AuthModule } from "./auth/auth.module";
import { ListarEquipoResolver } from "../resolvers/listar-equipo.resolver";
import { NuevoEquipoComponent } from "./equipo/nuevo-equipo/nuevo-equipo.component";
import { NuevoFaseComponent } from "./fase/nuevo-fase/nuevo-fase.component";
import { ListarFaseResolver } from "../resolvers/listar-fase.resolver";

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    LoginComponent,
    HomeComponent,
    RegistrarComponent,
    ListarEquipoComponent,
    ListarFaseComponent,
    NuevoFaseComponent,
    JuegoComponent,
    UsuarioComponent,
    GrupoUsuarioComponent,
    PerfilComponent,
    CardEquipoComponent,
    NuevoEquipoComponent,
    EditarEquipoComponent,
    EditarFaseComponent
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
    FileUploadModule,
    NgSelectModule
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
    EditarEquipoResolver,
    CambiosPendientesPerfil,
    FaseService,
    ListarFaseResolver,
    GrupoService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
