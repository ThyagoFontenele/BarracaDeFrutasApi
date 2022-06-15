import { Component } from '@angular/core';
import { ClientesService } from 'src/app/shared/clientes/clientes.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ErroResponse } from '../shared/erro-response.module';
import { SnackBarService, Status } from 'src/app/shared/snack-bar/snack-bar.service';

@Component({
  selector: 'app-registrar-clientes',
  templateUrl: './registrar-usuario.component.pug',
  styleUrls: ['./registrar-usuario.component.scss']
})
export class RegistrarUsuarioComponent {

  usuarioForm: FormGroup;

  constructor(
    private clientesService: ClientesService,
    private formBuilder: FormBuilder,
    private readonly router: Router,
    private readonly snackBar: SnackBarService
  ) {

    this.usuarioForm = this.formBuilder.group({
      nome: [null, [
        Validators.required,
        Validators.minLength(5),
        Validators.maxLength(40)
      ]],
      endereco: [null, [
        Validators.required,
        Validators.minLength(5),
        Validators.maxLength(50)
      ]],
      cpf: [null,[
        Validators.required,
        Validators.minLength(11),
        Validators.maxLength(11)
      ]],
      telefone: [null, [
        Validators.required,
        Validators.minLength(9),
        Validators.maxLength(15)
      ]],
      saldo: [null, [
        Validators.required,
        Validators.min(0),
        Validators.max(10000)
      ]],
    });
  }

  findError(parametro: string,): void {
    let errors = this.usuarioForm.controls[parametro].errors;

    if(errors){
      this.snackBar.open(ErroResponse.findError(parametro, errors), Status.Error);
    }
  }

  onSubmit(): void{
    this.clientesService.post(this.usuarioForm.value).subscribe({
      next: () => {
        this.snackBar.open("Usuário criado com sucesso.", Status.Success)
        setTimeout(() => {
          this.router.navigate(['login']);
        }, 1000)
      },
      error: () => this.snackBar.open("Erro: contate o suporte", Status.Error)
    });
  }
}
