import { Produto } from './produto.entity';

export class Categoria {
  id: string;
  nome: string;

  produtos: Produto[];

  constructor() {
    this.id = null,
    this.nome = null,
    this.produtos = null;
  }
}
