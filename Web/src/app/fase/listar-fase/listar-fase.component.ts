import { MensajeService } from "./../../../servicios/mensaje.service";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Fase } from "../../../model/Fase";
import { FaseService } from "../../../servicios/fase.service";

@Component({
  selector: "app-listar-fase",
  templateUrl: "./listar-fase.component.html",
  styleUrls: ["./listar-fase.component.css"]
})
export class ListarFaseComponent implements OnInit {
  listaFase: Fase[] = [] as Fase[];
  listaFaseTodos : Fase[] = [] as Fase[];

  constructor(
    private route: ActivatedRoute,
    private faseService: FaseService,
    private mensajeService: MensajeService
  ) {}

  ngOnInit() {
    this.cargarListaFase();
  }

  cargarListaFase() {
    this.route.data.subscribe(data => {
      this.listaFase = data["listaFase"];
      this.listaFaseTodos = data["listaFase"];
    });
  }

  buscarFase(event) {
    this.listaFase = [];

    this.listaFaseTodos.forEach(element => {

      if (element.nombre.toString().toLowerCase().indexOf(event.toLowerCase(), 0) >= 0) {
        this.listaFase.push(element);
      }
      
    });
  }

  eliminarFase(id) {
    this.mensajeService.confirm(
      "Esta seguro que quiere eliminar el registro",
      () => {
        this.faseService.eliminar(id).subscribe(
          fases => {
            this.listaFase = fases;
          },
          error => {
            this.mensajeService.error("Ocurrio un error interno");
          }
        );
      }
    );
  }
}
