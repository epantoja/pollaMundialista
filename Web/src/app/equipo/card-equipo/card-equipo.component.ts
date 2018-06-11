import { MensajeService } from "./../../../servicios/mensaje.service";
import { EquipoService } from "./../../../servicios/equipo.service";
import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";
import { Equipo } from "../../../model/Equipo";

@Component({
  selector: "app-card-equipo",
  templateUrl: "./card-equipo.component.html",
  styleUrls: ["./card-equipo.component.css"]
})
export class CardEquipoComponent implements OnInit {
  @Input() equipo: Equipo;
  @Output() desdeCardEquipo = new EventEmitter();

  constructor(
    private equipoService: EquipoService,
    private mensajeService: MensajeService
  ) {}

  ngOnInit() {}

  eliminarEquipo(id) {
    this.mensajeService.confirm(
      "Esta seguro que quiere eliminar el equipo",
      () => {
        this.equipoService.eliminarEquipo(id).subscribe(
          () => {
            this.mensajeService.success("Equipo eliminado correctamente");
            this.equipoService.listarActivos().subscribe(equipos => {
              this.desdeCardEquipo.emit(equipos);
            });
          },
          error => {
            this.mensajeService.error("Ocurrio un error interno");
          }
        );
      }
    );
  }
}
