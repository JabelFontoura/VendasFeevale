import { Usuario } from './usuario.entity';
import { Situacao } from './enums/situacao.enum';
import { DetalheVenda } from './detalhe-venda.entity';

export class CabecalhoVenda {
  id: string;
  idCliente: string;
  data: Date;
  hora: string;
  situacao: Situacao;
  dataExpedicao: Date;
  dataAceite: Date;

  idClienteNavigation: Usuario;
  detVenda: DetalheVenda[];
}