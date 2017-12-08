import { Produto } from './produto.entity';
import { Preco } from './preco.entity';
import { CabecalhoVenda } from './cabecalho-venda.entity';

export class DetalheVenda {
  id: string;

  idCabecalhoVenda: string;
  idProduto: string;
  idPreco: string;
  cabecalhoVenda: CabecalhoVenda;
  preco: Preco;
  produto: Produto;
}
