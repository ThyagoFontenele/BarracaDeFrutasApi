import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Produto } from 'src/app/shared/produto';
import { ProdutosService } from 'src/app/shared/produtos/produtos.service';

@Component({
  selector: 'app-produto-details',
  templateUrl: './produto-details.component.pug',
  styleUrls: ['./produto-details.component.scss']
})
export class ProdutoDetailsComponent implements OnInit {

  produto!: Produto;

  constructor(private route: ActivatedRoute, private produtoService: ProdutosService)
  {}

  ngOnInit(): void {
    const selectedId = Number(this.route.snapshot.paramMap.get('id'));
    this.produtoService.getById(selectedId).subscribe(produto => this.produto = produto);
  }
}
