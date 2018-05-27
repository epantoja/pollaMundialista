import { MensajeService } from "./../../../servicios/mensaje.service";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { GrupoEquipo } from "../../../model/GrupoEquipo";
import { GrupoEquipoService } from "../../../servicios/grupoEquipo.service";

@Component({
  selector: "app-listar-grupoEquipo",
  templateUrl: "./listar-grupoEquipo.component.html",
  styleUrls: ["./listar-grupoEquipo.component.css"]
})
export class ListarGrupoEquipoComponent implements OnInit {
  listaGrupoEquipo: GrupoEquipo[] = [] as GrupoEquipo[];
  listaGrupoEquipoTodos : GrupoEquipo[] = [] as GrupoEquipo[];

  constructor(
    private route: ActivatedRoute,
    private grupoEquipoService: GrupoEquipoService,
    private mensajeService: MensajeService
  ) {}

  ngOnInit() {
    this.cargarListaGrupoEquipo();
  }

  cargarListaGrupoEquipo() {
    this.route.data.subscribe(data => {
      this.listaGrupoEquipo = data["listaGrupoEquipo"];
      this.listaGrupoEquipoTodos = data["listaGrupoEquipo"];
    });
  }

  buscarGrupoEquipo(event) {
    this.listaGrupoEquipo = [];

    this.listaGrupoEquipoTodos.forEach(element => {

      if (element.nombre.toString().toLowerCase().indexOf(event.toLowerCase(), 0) >= 0) {
        this.listaGrupoEquipo.push(element);
      }
      
    });
  }

  eliminarGrupoEquipo(id) {
    this.mensajeService.confirm(
      "Esta seguro que quiere eliminar el registro",
      () => {
        this.grupoEquipoService.eliminar(id).subscribe(
          grupoEquipos => {
            this.listaGrupoEquipo = grupoEquipos;
          },
          error => {
            this.mensajeService.error("Ocurrio un error interno");
          }
        );
      }
    );
  }
}
