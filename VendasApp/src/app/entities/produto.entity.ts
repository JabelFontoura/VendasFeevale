import { Preco } from './preco.entity';
import { DetalheVenda } from './detalhe-venda.entity';
import { Categoria } from './categoria.entity';

export class Produto {
  id: string;
  nome: string;
  idCategoria: string;
  urlImagem: string;

  categoria: Categoria;
  detalheVendas: DetalheVenda[];
  preco: Preco[];

  constructor() {
    this.id = null,
    this.nome = null,
    this. idCategoria = null,
    this.urlImagem = null,
    this.categoria = null,
    this.detalheVendas = null,
    this.preco = null;
  }
}
