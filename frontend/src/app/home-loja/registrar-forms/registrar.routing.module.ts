import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistrarProdutoComponent } from './produtos/registrar-produto.component';
import { RegistrarUsuarioComponent } from './usuarios/registrar-usuario.component';


const routes: Routes = [
  {
    path: 'produto',
    component: RegistrarProdutoComponent,
  },
  {
    path: 'usuario',
    component: RegistrarUsuarioComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RegistrarRoutingModule { }
