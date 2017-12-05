import { CabecalhoVenda } from './cabecalho-venda.entity';
import { Tipo } from "./enums/tipo.enum";

export class Usuario {
  id: string;
  login: string;
  email: string;
  tipo: Tipo;
  nome: string;
  senha: string;
  cabVenda: CabecalhoVenda[];
}