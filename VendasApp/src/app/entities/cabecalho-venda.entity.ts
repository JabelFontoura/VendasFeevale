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

  situacaoDescricao: string;

  constructor() {
    this.id = null,
    this.data = null,
    this.hora = null,
    this.situacao = Situacao.pendente,
    this.dataExpedicao = null,
    this.dataAceite = null,

    this.usuario = null,
    this.detalheVendas = [],
    this.idUsuario = null;
  }
}
