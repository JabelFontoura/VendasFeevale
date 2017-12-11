import { DetalheVenda } from '../../../entities/detalhe-venda.entity';
import { DetalheVendasService } from '../../../services/detalhe-vendas.service';
import { Situacao } from '../../../entities/enums/situacao.enum';
import { ProdutosService } from '../../../services/produtos.service';
import { CabecalhoVendasService } from '../../../services/cabecalho-vendas.service';
import { LocalStorageService } from '../../../services/localstorage.service';
import { selector } from 'rxjs/operator/publish';
import { Component, OnInit } from '@angular/core';
import { CabecalhoVenda } from '../../../entities/cabecalho-venda.entity';

@Component({
  selector: 'app-carrinho',
  templateUrl: './carrinho.component.html',
  styleUrls: ['./carrinho.component.css']
})
export class CarrinhoComponent implements OnInit {

  private idUsuario = this.localStorageService.getIdUsuario();

  public pedidoAtual = new CabecalhoVenda();
  public historicoPedidos: CabecalhoVenda[];

  constructor(
    private produtosService: ProdutosService,
    private cabecalhoVendasService: CabecalhoVendasService,
    private detalheVendasService: DetalheVendasService,
    private localStorageService: LocalStorageService
  ) { }

  ngOnInit() {
    this.carregarPedidos();
  }

  carregarPedidos(): void {
    this.cabecalhoVendasService.findByIdUsuarioAndSituacao(this.idUsuario, Situacao.pendente)
    .subscribe(data => {
      this.pedidoAtual.situacao = null;
      this.pedidoAtual = <any> data || this.pedidoAtual;
      this.pedidoAtual.situacaoDescricao = <any> this.mapSituacao(this.pedidoAtual.situacao);
      this.detalheVendasService.findByIdCabecalhoVenda(this.pedidoAtual.id).subscribe(det => this.pedidoAtual.detalheVendas = <any> det);
    });

    this.cabecalhoVendasService.findByIdUsuario(this.idUsuario).subscribe(data => {
      this.historicoPedidos = <any> data;
      this.historicoPedidos.map(p => p.situacaoDescricao = this.mapSituacao(p.situacao));
    });
  }

  remover(id: string): void {
    this.pedidoAtual.detalheVendas = this.removeByAttr(this.pedidoAtual.detalheVendas, 'id', id);
    this.detalheVendasService.delete(id).subscribe();
  }

  private mapSituacao(s: Situacao): string {
    switch (s) {
      case 0:
        return 'Pendente';

      case 1:
        return 'Aprovado';

      case 3:
        return 'Reprovado';
    }
  }

  private removeByAttr (arr, attr, value) {
    let i = arr.length;
    while (i--) {
       if (arr[i] && arr[i].hasOwnProperty(attr) && (arguments.length > 2 && arr[i][attr] === value ) ) {
           arr.splice(i, 1);
       }
    }
    return arr;
  }
}
