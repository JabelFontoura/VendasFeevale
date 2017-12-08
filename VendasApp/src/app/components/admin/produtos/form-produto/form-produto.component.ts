import { CategoriasService } from '../../../../services/categorias.service';
import { Categoria } from '../../../../entities/categoria.entity';
import { ProdutosService } from '../../../../services/produtos.service';
import { Produto } from '../../../../entities/produto.entity';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { OnDestroy } from '@angular/core/src/metadata/lifecycle_hooks';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-form-produto',
  templateUrl: './form-produto.component.html',
  styleUrls: ['./form-produto.component.css']
})
export class FormProdutoComponent implements OnInit {

  public produto = new Produto();
  public salvar: Function;
  public editando: boolean;
  public categorias: Categoria[];

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private produtosService: ProdutosService,
    private categoriasService: CategoriasService
  ) { }

  ngOnInit() {
    this.definirContexto();
    this.carregarCategorias();
  }

  onSubmit(f: FormGroup) {
    this.salvar(this.produto);
  }

  carregarCategorias(): void {
    this.categoriasService.findAll().subscribe(data => this.categorias = <any> data);
  }

  definirContexto(): void {
    this.route.params.subscribe(params => {
      const { id } = params;
      if (id) {
        this.produtosService.findById(id).subscribe(data => {
          if (data) {
            this.produto = <any> data;
            this.salvar = this.editar;
            this.editando = true;
          } else {
            this.router.navigate(['/admin/produtos/novo']);
          }
        });
      } else {
        this.salvar = this.adicionar;
        this.editando = false;
      }
    });
  }

  private adicionar = (produto: Produto): void  => {
    this.produtosService.add(produto).subscribe(result => this.router.navigate(['/admin/produtos']));
  }

  private editar = (produto: Produto): void => {
    this.produtosService.update(produto).subscribe(result => this.router.navigate(['/admin/produtos']));
  }
}
