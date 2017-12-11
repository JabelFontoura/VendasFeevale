import { CategoriasService } from '../../../services/categorias.service';
import { Categoria } from '../../../entities/categoria.entity';
import { DetalheVenda } from '../../../entities/detalhe-venda.entity';
import { Situacao } from '../../../entities/enums/situacao.enum';
import { LocalStorageService } from '../../../services/localstorage.service';
import { CabecalhoVendasService } from '../../../services/cabecalho-vendas.service';
import { selector } from 'rxjs/operator/publish';
import { CabecalhoVenda } from '../../../entities/cabecalho-venda.entity';
import { ProdutosService } from '../../../services/produtos.service';
import { Produto } from '../../../entities/produto.entity';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-categorias',
  templateUrl: './categorias.component.html',
  styleUrls: ['./categorias.component.css']
})
export class CategoriasComponent implements OnInit {

  public categorias: Categoria[];
  public odernadoCrescente: boolean;
  public pedido: CabecalhoVenda = new CabecalhoVenda();

  private produtos: Produto[];

  constructor(
    private categoriasService: CategoriasService,
    private cabecalhoVendasService: CabecalhoVendasService,
    private produtosService: ProdutosService,
    private localStorageService: LocalStorageService
  ) { }

  ngOnInit() {
    this.carregarCategorias();
    this.iniciarCarrinho();
    this.carregarProdutos();
  }

  iniciarCarrinho(): void {
    const id = this.localStorageService.getIdUsuario();

    this.cabecalhoVendasService.findByIdUsuarioAndSituacao(id, Situacao.pendente)
    .subscribe(result => {
      const pedido = <any> result;
      if (pedido) {
        this.pedido = pedido;
      }
      this.pedido.idUsuario = id;
    });
  }

  carregarCategorias(): void {
    this.categoriasService.findAll().subscribe(data => {
      this.categorias = <any> data;
      this.categorias.forEach(c => {
          c.produtos.forEach(p => {
          this.produtosService.findById(p.id).subscribe(result => {
            c.produtos[c.produtos.findIndex(a => a.id === p.id)] = <any> result;
          });
        });
      });
    });
  }

  carregarProdutos(): void {
    this.produtosService.findAll().subscribe(data => this.produtos = <any> data);
  }

  adicionar(id: string): void {
    this.pedido.data = new Date();
    const venda = new DetalheVenda();

    venda.idProduto = id;
    venda.idPreco = this.produtos.filter(p => p.id === id)[0].preco[0].id;

    this.pedido.detalheVendas.push(venda);
    if (this.pedido.id) {
      this.cabecalhoVendasService.update(this.pedido)
        .subscribe(result => this.pedido = <any> result);
    } else {
      this.cabecalhoVendasService.add(this.pedido)
        .subscribe(result => this.pedido = <any> result);
    }
  }

  ordenar(ordem: string): void {
    this.categorias.forEach(c => {
      c.produtos.sort((a, b) => {
      let valorA: number;
      let valorB: number;

      if (ordem === 'crescente') {
        valorA = a.preco[0].valor;
        valorB = b.preco[0].valor;
        this.odernadoCrescente = true;
      } else {
        valorB = a.preco[0].valor;
        valorA = b.preco[0].valor;
        this.odernadoCrescente = false;
      }

        if (valorA < valorB) {
          return -1;
        } else if (valorA > valorB) {
          return 1;
        } else {
          return 0;
        }
      });
    });
  }

}
