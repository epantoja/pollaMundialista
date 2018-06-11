import { NuevoJuegoComponent } from "./juego/nuevo-juego/nuevo-juego.component";
import { EditarFaseComponent } from "./fase/editar-fase/editar-fase.component";
import { ListarFaseResolver } from "./../resolvers/listar-fase.resolver";
import { CambiosPendientesPerfil } from "./../guards/cambiosPendientesPerfil.guard";
import { ListarFaseComponent } from "./fase/listar-fase/listar-fase.component";
import { EditarEquipoResolver } from "./../resolvers/editar-equipo.resolver";
import { EditarEquipoComponent } from "./equipo/editar-equipo/editar-equipo.component";
import { NuevoEquipoComponent } from "./equipo/nuevo-equipo/nuevo-equipo.component";
import { ListarEquipoComponent } from "./equipo/listar-equipo/listar-equipo.component";
import { UsuarioResolver } from "./../resolvers/usuario.resolver";
import { PerfilComponent } from "./perfil/perfil.component";
import { LoginGuard } from "./../guards/login.guard";
import { GrupoUsuarioComponent } from "./grupoUsuario/grupoUsuario.component";
import { UsuarioComponent } from "./usuario/usuario.component";
import { ListaJuegoComponent } from "./juego/lista-juego/lista-juego.component";
import { LoginComponent } from "./login/login.component";

import { Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { RegistrarComponent } from "./registrar/registrar.component";
import { AuthGuard } from "../guards/auth.guard";
import { AuthAdminGuard } from "../guards/authAdmin.guard";
import { ListarEquipoResolver } from "../resolvers/listar-equipo.resolver";
import { NuevoFaseComponent } from "./fase/nuevo-fase/nuevo-fase.component";

export const appRoutes: Routes = [
  {
    path: "",
    runGuardsAndResolvers: "always",
    canActivate: [AuthAdminGuard],
    children: [
      {
        path: "administrar/equipos",
        component: ListarEquipoComponent,
        resolve: { listaEquipos: ListarEquipoResolver }
      },
      {
        path: "administrar/equipos/nuevoEquipo",
        component: NuevoEquipoComponent
      },
      {
        path: "administrar/equipos/editarEquipo/:id",
        component: EditarEquipoComponent
      },
      {
        path: "administrar/fases",
        resolve: { listaFase: ListarFaseResolver },
        component: ListarFaseComponent
      },
      {
        path: "administrar/fases/nuevaFase",
        component: NuevoFaseComponent
      },
      {
        path: "administrar/fases/editarFase/:id",
        component: EditarFaseComponent
      },
      { path: "administrar/juegos", component: ListaJuegoComponent },
      { path: "administrar/juegos/nuevoJuego", component: NuevoJuegoComponent },
      { path: "administrar/usuarios", component: UsuarioComponent },
      { path: "administrar/grupoUsuarios", component: GrupoUsuarioComponent }
    ]
  },
  {
    path: "",
    runGuardsAndResolvers: "always",
    canActivate: [AuthGuard],
    children: [
      {
        path: "perfil",
        component: PerfilComponent,
        resolve: { usuarioDetalle: UsuarioResolver },
        canDeactivate: [CambiosPendientesPerfil]
      }
    ]
  },
  { path: "home", component: HomeComponent },
  { path: "login", component: LoginComponent, canActivate: [LoginGuard] },
  {
    path: "registrar",
    component: RegistrarComponent,
    canActivate: [LoginGuard]
  },
  { path: "**", redirectTo: "home", pathMatch: "full" }
];
