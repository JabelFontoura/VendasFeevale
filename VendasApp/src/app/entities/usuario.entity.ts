import { CabecalhoVenda } from './cabecalho-venda.entity';
import { Tipo } from './enums/tipo.enum';

export class Usuario {
  id: string;
  login: string;
  email: string;
  tipo: Tipo;
  nome: string;
  senha: string;
  
  cabecalhoVenda: CabecalhoVenda[];

  constructor() {
    this.id = null,
    this.login = null,
    this.email = null,
    this.tipo = null,
    this.nome = null,
    this.senha = null,
    this.cabecalhoVenda = null;
  }

}
