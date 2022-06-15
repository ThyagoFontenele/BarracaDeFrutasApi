import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { RegistrarProdutoComponent } from './produtos/registrar-produto.component';
import { RegistrarUsuarioComponent } from './usuarios/registrar-usuario.component';
import { RegistrarRoutingModule } from './registrar.routing.module';


@NgModule({
  declarations: [
    RegistrarProdutoComponent,
    RegistrarUsuarioComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    RegistrarRoutingModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class RegistrarModule { }
