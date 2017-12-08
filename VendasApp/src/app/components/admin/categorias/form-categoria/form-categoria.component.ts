import { Component, OnInit } from '@angular/core';
import { CategoriasService } from '../../../../services/categorias.service';
import { Categoria } from '../../../../entities/categoria.entity';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-form-categoria',
  templateUrl: './form-categoria.component.html',
  styleUrls: ['./form-categoria.component.css']
})
export class FormCategoriaComponent implements OnInit {

  public salvar: Function;
  public editando: boolean;
  public categorias: Categoria[];
  public categoria = new Categoria();

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private categoriasService: CategoriasService
  ) { }

  ngOnInit() {
    this.definirContexto();
    this.carregarCategorias();
  }

  onSubmit(f: FormGroup) {
    this.salvar(this.categoria);
  }

  carregarCategorias(): void {
    this.categoriasService.findAll().subscribe(data => this.categorias = <any> data);
  }

  definirContexto(): void {
    this.route.params.subscribe(params => {
      const { id } = params;
      if (id) {
        this.categoriasService.findById(id).subscribe(data => {
          if (data) {
            this.categoria = <any> data;
            this.salvar = this.editar;
            this.editando = true;
          } else {
            this.router.navigate(['/admin/categorias/novo']);
          }
        });
      } else {
        this.salvar = this.adicionar;
        this.editando = false;
      }
    });
  }

  private adicionar = (categoria: Categoria): void  => {
    this.categoriasService.add(categoria).subscribe(result => this.router.navigate(['/admin/categorias']));
  }

  private editar = (categoria: Categoria): void => {
    this.categoriasService.update(categoria).subscribe(result => this.router.navigate(['/admin/categorias']));
  }

}
