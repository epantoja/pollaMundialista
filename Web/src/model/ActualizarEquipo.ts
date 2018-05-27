export interface ActualizarEquipo {
  id: string;
  nombre: string;
  banderaUrl: string;
  partidosJugados: number;
  partidosGanados: number;
  partidosEmpatados: number;
  partidosPerdidos: number;
  golesAFavor: number;
  golesEnContra: number;
  diferenciaGoles: number;
  puntos: number;
}
