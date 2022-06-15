import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PerfilComponent } from './perfil.component';
import { AppRoutingModule } from '../app-routing.module';

@NgModule({
  declarations: [
    PerfilComponent
  ],
  imports: [
    CommonModule,
    AppRoutingModule
  ]
})
export class PerfilModule { }
