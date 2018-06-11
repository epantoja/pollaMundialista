import { Component, OnInit, HostListener } from "@angular/core";
import { UsuarioService } from "../../servicios/usuario.service";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"]
})
export class HomeComponent implements OnInit {
  constructor() {}

  ngOnInit() {}

  @HostListener("window:scroll", [])
  onWindowScroll() {
    console.log("Scrolling!");
    this.myFunction();
  }

  myFunction() {
    var header = document.getElementById("myHeader");
    var sticky = header.offsetTop;

    if (window.pageYOffset + 50 >= sticky) {
      header.classList.add("sticky");
    } else {
      header.classList.remove("sticky");
    }
  }
}
