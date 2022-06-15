import { Component, OnInit } from '@angular/core';
import { Produto } from 'src/app/shared/produto';
import { ProdutosService } from '../shared/produtos/produtos.service';
@Component({
  selector: 'app-home-loja',
  templateUrl: './home-loja.component.pug',
  styleUrls: ['./home-loja.component.scss']
})
export class HomeLojaComponent implements OnInit {

  produtos!: Produto[];

  constructor(private produtosService: ProdutosService) {

  }

  ngOnInit(): void {
    this.produtosService.get().subscribe(produtos => this.produtos = produtos);
  }
}
