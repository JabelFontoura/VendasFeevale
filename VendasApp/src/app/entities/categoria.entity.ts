import { Produto } from './produto.entity';

export class Categoria {
  id: string;
  nome: string;

  produtos: Produto[];
}
