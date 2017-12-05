import { Produto } from './produto.entity';
import { DetalheVenda } from './detalhe-venda.entity';

export class Preco {
  id: string;
  valor: number;
  data: Date;
  idProduto: string;
  dataValidade: Date;

  idProdutoNavigation: Produto;
  detVenda: DetalheVenda[];
} 
