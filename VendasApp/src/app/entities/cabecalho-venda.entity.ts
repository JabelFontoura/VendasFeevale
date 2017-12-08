import { Usuario } from './usuario.entity';
import { Situacao } from './enums/situacao.enum';
import { DetalheVenda } from './detalhe-venda.entity';

export class CabecalhoVenda {
  id: string;
  data: Date;
  hora: string;
  situacao: Situacao;
  dataExpedicao: Date;
  dataAceite: Date;

  usuario: Usuario;
  detalheVendas: DetalheVenda[];
  idUsuario: string;
}
