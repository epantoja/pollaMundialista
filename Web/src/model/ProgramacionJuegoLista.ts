import { Equipo } from "./Equipo";
import { Fase } from "./Fase";

export interface ProgramacionJuegoLista {
  id: number;
  equipoA: Equipo;
  equipoB: Equipo;
  fase: Fase;
  marcadorA: number;
  marcadorB: number;
  fechaJuego: Date;
  Orden: number;
}
