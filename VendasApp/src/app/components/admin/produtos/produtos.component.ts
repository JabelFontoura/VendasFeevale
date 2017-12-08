import { Router } from '@angular/router';
import { Produto } from '../../../entities/produto.entity';
import { Component, OnInit } from '@angular/core';
import { ProdutosService } from '../../../services/produtos.service';

@Component({
  selector: 'app-produtos',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.css']
})
export class ProdutosComponent implements OnInit {

  public produtos: Produto[];

  constructor(
    private produtosService: ProdutosService,
    private router: Router
  ) { }

  ngOnInit() {
    this.carregarProdutos();
  }

  carregarProdutos(): void {
    this.produtosService.findAll()
    .subscribe(data => this.produtos = <any> data);
  }

  editar(id: string): void {
    this.router.navigate(['/admin/produtos/editar', id]);
  }

  deletar(id: string) {
    this.produtosService.delete(id).subscribe(result => this.carregarProdutos());
  }
}
