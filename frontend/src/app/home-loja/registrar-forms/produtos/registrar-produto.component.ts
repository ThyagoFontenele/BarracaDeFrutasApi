import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { ErroResponse } from '../shared/erro-response.module';
import { SnackBarService, Status } from 'src/app/shared/snack-bar/snack-bar.service';
import { ProdutosService } from 'src/app/shared/produtos/produtos.service';


@Component({
  selector: 'app-registrar-produto',
  templateUrl: './registrar-produto.component.pug',
  styleUrls: ['./registrar-produto.component.scss']
})
export class RegistrarProdutoComponent {

  produtoForm: FormGroup;

  constructor(
    private produtoService: ProdutosService,
    private formBuilder: FormBuilder,
    private readonly router: Router,
    private readonly snackBar: SnackBarService
  ) {

    this.produtoForm = this.formBuilder.group({
      nome: [null, [
        Validators.required,
        Validators.minLength(5),
        Validators.maxLength(30),
      ]],
      tipo: [null, [
        Validators.required,
        Validators.minLength(4),
        Validators.maxLength(20),
      ]],
      unidades: [null, [
        Validators.required,
        Validators.min(1),
        Validators.max(10000),
      ]],
      preco: [null, [
        Validators.required,
        Validators.min(0.1),
        Validators.max(1000),
      ]],
      imgUrl: [null, [
        Validators.required,
        Validators.minLength(50),
        Validators.maxLength(200),
      ]],
    });
  }

  findError(parametro: string,): void {
    let errors = this.produtoForm.controls[parametro].errors;
    if(errors){
      this.snackBar.open(ErroResponse.findError(parametro, errors), Status.Error);
    }

  }

  onSubmit(): void{
    this.produtoService.post(this.produtoForm.value).subscribe({
      next: () => {
        this.snackBar.open("Produto criado com sucesso.", Status.Success)
        setTimeout(() => {
          this.router.navigate(['produtos']);
        }, 1000)
      },
      error: () => this.snackBar.open("Erro: contate o suporte", Status.Error)
    });
  }
}
