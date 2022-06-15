import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeLojaComponent } from './home-loja.component';
import { HomeLojaRoutingModule } from './home-loja.routing.module';
import { ProdutoDetailsComponent } from './produto-details/produto-details.component';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    HomeLojaComponent,
    LoginComponent,
    ProdutoDetailsComponent
  ],
  imports: [
    CommonModule,
    HomeLojaRoutingModule
  ]
})
export class HomeLojaModule { }
