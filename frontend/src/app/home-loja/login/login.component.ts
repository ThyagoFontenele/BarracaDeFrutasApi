import { Component } from '@angular/core';
import { Usuario } from 'src/app/shared/usuario';
import { ClientesService } from 'src/app/shared/clientes/clientes.service';
import { Logado } from 'src/app/shared/logado';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.pug',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  usuarios!: Usuario[];

  constructor(private usuariosService: ClientesService) {
    usuariosService.get().subscribe(usuarios => this.usuarios = usuarios);
  }

  logar(usuario: Usuario): void {
    Logado.logar(usuario);
  }

  excluirUsuario(id: number){
    this.usuariosService.delete(id).subscribe();
  }
}
