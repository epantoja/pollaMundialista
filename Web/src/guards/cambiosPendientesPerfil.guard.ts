import { MensajeService } from "./../servicios/mensaje.service";
import { PerfilComponent } from "./../app/perfil/perfil.component";
import { Injectable } from "@angular/core";
import { CanDeactivate } from "@angular/router";
declare let alertify: any;

@Injectable()
export class CambiosPendientesPerfil implements CanDeactivate<PerfilComponent> {
  canDeactivate(component: PerfilComponent) {
    if (component.frmActualizarUsuario.dirty) {
      return confirm("Seguro que quieres continuar? Perderas tus cambios.!");
    }
    return true;
  }
}
