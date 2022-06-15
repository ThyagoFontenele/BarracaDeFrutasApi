import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeLojaComponent } from './home-loja.component';
import { LoginComponent } from './login/login.component';
import { ProdutoDetailsComponent } from './produto-details/produto-details.component';

const routes: Routes = [
  {path: '', component: HomeLojaComponent},
  {path: 'produto/:id', component: ProdutoDetailsComponent},
  {path: 'login', component: LoginComponent},
  {
    path: 'registrar',
    loadChildren: () => import('./registrar-forms/registrar.module').then(m => m.RegistrarModule)
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeLojaRoutingModule { }
