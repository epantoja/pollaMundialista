import { MensajeService } from "./../../../servicios/mensaje.service";
import { ProgramacionJuegoLista } from "./../../../model/ProgramacionJuegoLista";
import { Component, OnInit, Input } from "@angular/core";

@Component({
  selector: "app-card-juego",
  templateUrl: "./card-juego.component.html",
  styleUrls: ["./card-juego.component.css"]
})
export class CardJuegoComponent implements OnInit {
  @Input()
  programacionJuego: ProgramacionJuegoLista = {} as ProgramacionJuegoLista;

  constructor(private mensajeService: MensajeService) {}

  ngOnInit() {}

  editarJuego(id: number) {
    alert(id);
  }

  eliminarJuego(id: number) {
    alert(id);
  }
}
