import { Preco } from './preco.entity';
import { DetalheVenda } from './detalhe-venda.entity';
import { Categoria } from './categoria.entity';

export class Produto {
  id: string;
  nome: string;
  idCategoria: string;

  idCategoriaNavigation: Categoria;
  detVenda: DetalheVenda[];
  preco: Preco[];
}