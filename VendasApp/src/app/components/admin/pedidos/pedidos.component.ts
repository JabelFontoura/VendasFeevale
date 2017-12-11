import { Situacao } from '../../../entities/enums/situacao.enum';
import { CabecalhoVenda } from '../../../entities/cabecalho-venda.entity';
import { DetalheVendasService } from '../../../services/detalhe-vendas.service';
import { LocalStorageService } from '../../../services/localstorage.service';
import { selector } from 'rxjs/operator/publish';
import { CabecalhoVendasService } from '../../../services/cabecalho-vendas.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-pedidos',
  templateUrl: './pedidos.component.html',
  styleUrls: ['./pedidos.component.css']
})
export class PedidosComponent implements OnInit {

  public pedidos: CabecalhoVenda[];

  constructor(
    private cabecalhoVendasService: CabecalhoVendasService,
    private detalheVendasService: DetalheVendasService,
    private localStorageService: LocalStorageService
  ) { }

  ngOnInit() {
    this.carregarPedidos();
  }

  carregarPedidos(): void {
    this.cabecalhoVendasService.findAll().subscribe(data => {
      this.pedidos = <any> data;
      this.pedidos.forEach(p => {
        p.situacaoDescricao = this.mapSituacao(p.situacao);
        this.detalheVendasService.findByIdCabecalhoVenda(p.id).subscribe(det => p.detalheVendas = <any> det);
      });
    });
  }

  aprovar(id: string): void {
    this.atualizarStatus(id, Situacao.aprovado);
  }

  reprovar(id: string): void {
    this.atualizarStatus(id, Situacao.reprovado);
  }

  private atualizarStatus(id: string, situacao: Situacao): void {
    this.cabecalhoVendasService.findById(id).subscribe(data => {
      const pedido = <any> data;
      pedido.situacao = situacao;

      this.cabecalhoVendasService.update(pedido).subscribe(result => this.carregarPedidos());
    });
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
}
