import { EditarEquipoResolver } from "./../resolvers/editar-equipo.resolver";
import { EditarEquipoComponent } from "./equipo/editar-equipo/editar-equipo.component";
import { NuevoEquipoComponent } from "./equipo/nuevo-equipo/nuevo-equipo.component";
import { ListarEquipoComponent } from "./equipo/listar-equipo/listar-equipo.component";
import { UsuarioResolver } from "./../resolvers/usuario.resolver";
import { PerfilComponent } from "./perfil/perfil.component";
import { LoginGuard } from "./../guards/login.guard";
import { GrupoUsuarioComponent } from "./grupoUsuario/grupoUsuario.component";
import { UsuarioComponent } from "./usuario/usuario.component";
import { JuegoComponent } from "./juego/juego.component";
import { GrupoEquipoComponent } from "./grupoEquipo/grupoEquipo.component";
import { LoginComponent } from "./login/login.component";

import { Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { RegistrarComponent } from "./registrar/registrar.component";
import { AuthGuard } from "../guards/auth.guard";
import { AuthAdminGuard } from "../guards/authAdmin.guard";
import { ListarEquipoResolver } from "../resolvers/listar-equipo.resolver";

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
      { path: "administrar/grupoEquipos", component: GrupoEquipoComponent },
      { path: "administrar/juegos", component: JuegoComponent },
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
        resolve: { usuarioDetalle: UsuarioResolver }
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
