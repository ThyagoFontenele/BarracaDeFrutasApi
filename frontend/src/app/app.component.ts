import { Component } from '@angular/core';
import { Usuario } from './shared/usuario';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.pug',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'BarracaDeFrutas';

  usuario?: Usuario;
  logado = false;
}
