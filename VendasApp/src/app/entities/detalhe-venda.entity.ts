import { Produto } from './produto.entity';
import { Preco } from './preco.entity';
import { CabecalhoVenda } from './cabecalho-venda.entity';

export class DetalheVenda {
  id: string;
  idCab: string;
  idProduto: string;
  idPreco: string;

  idCabNavigation: CabecalhoVenda;
  idPrecoNavigation: Preco;
  idProdutoNavigation: Produto;
}