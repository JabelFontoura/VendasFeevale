import { Produto } from './produto.entity';
import { DetalheVenda } from './detalhe-venda.entity';

export class Preco {
  id: string;
  valor: number;
  data: Date;
  dataValidade: Date;

  produto: Produto;
  detalheVendas: DetalheVenda[];
  idProduto: string;

  constructor() {
    this.id = null,
    this.valor = null,
    this.data = null,
    this.dataValidade = null,
    this.produto = null,
    this.detalheVendas = null,
    this.idProduto = null;
  }
}
