import { GrupoUsuario } from "./GrupoUsuario";

export interface DetalleUsuario {
  id: number;
  codUsuario: string;
  nombres: string;
  estado: boolean;
  grupoActual: GrupoUsuario;
  grupoUsuario: GrupoUsuario[];
}
