import { Equipo } from "./../../../model/Equipo";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-listar-equipo",
  templateUrl: "./listar-equipo.component.html",
  styleUrls: ["./listar-equipo.component.css"]
})
export class ListarEquipoComponent implements OnInit {
  listaEquipos: Equipo[] = [] as Equipo[];
  listaEquiposTodos : Equipo[] = [] as Equipo[];

  constructor(private route: ActivatedRoute) {}

  ngOnInit() {
    this.obtenerEquipos();
  }

  obtenerEquipos() {
    this.route.data.subscribe(data => {
      this.listaEquipos = data["listaEquipos"];
      this.listaEquiposTodos = data["listaEquipos"];
    });
  }

  buscarEquipo(event: string) {
    this.listaEquipos = [];

    this.listaEquiposTodos.forEach(element => {

      if (element.nombre.toString().toLowerCase().indexOf(event.toLowerCase(), 0) >= 0) {
        this.listaEquipos.push(element);
      }
      
    });
 
  }

  recibirListaEquipos(event: Equipo[]) {
    this.listaEquipos = event;
  }
}
