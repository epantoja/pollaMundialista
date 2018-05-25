import { Injectable } from "@angular/core";
declare let alertify: any;

@Injectable()
export class MensajeService {
  confirm(message: string, okCallback: () => any) {
    alertify.confirm(message, function(e) {
      if (e) {
        okCallback();
      }
    });
  }

  success(message: string) {
    alertify.success(message);
  }

  error(message: string) {
    alertify.error(message);
  }

  waring(message: string) {
    alertify.waring(message);
  }

  message(message: string) {
    alertify.message(message);
  }
}
