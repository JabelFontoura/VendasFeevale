import { ProdutosService } from '../../../../services/produtos.service';
import { Component, OnInit } from '@angular/core';
import { PrecosService } from '../../../../services/precos.service';
import { Preco } from '../../../../entities/preco.entity';
import { Produto } from '../../../../entities/produto.entity';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup } from '@angular/forms';


@Component({
  selector: 'app-form-preco',
  templateUrl: './form-preco.component.html',
  styleUrls: ['./form-preco.component.css']
})
export class FormPrecoComponent implements OnInit {

  public salvar: Function;
  public editando: boolean;
  public precos: Preco[];
  public preco = new Preco();
  public produtos: Produto[];

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private precosService: PrecosService,
    private produtosService: ProdutosService
  ) { }

  ngOnInit() {
    this.definirContexto();
    this.carregarPrecos();
    this.carregarProdutos();
  }

  onSubmit(f: FormGroup) {
    this.salvar(this.preco);
  }

  carregarPrecos(): void {
    this.precosService.findAll().subscribe(data => this.precos = <any> data);
  }

  carregarProdutos(): void {
    this.produtosService.findAll().subscribe(data => this.produtos = <any> data);
  }

  definirContexto(): void {
    this.route.params.subscribe(params => {
      const { id } = params;
      if (id) {
        this.precosService.findById(id).subscribe(data => {
          if (data) {
            this.preco = <any> data;
            this.salvar = this.editar;
            this.editando = true;
          } else {
            this.router.navigate(['/admin/precos/novo']);
          }
        });
      } else {
        this.salvar = this.adicionar;
        this.editando = false;
      }
    });
  }

  private adicionar = (preco: Preco): void  => {
    console.log(preco)
    preco.data = new Date();
    this.precosService.add(preco).subscribe(result => this.router.navigate(['/admin/precos']));
  }

  private editar = (preco: Preco): void => {
    this.precosService.update(preco).subscribe(result => this.router.navigate(['/admin/precos']));
  }
}
