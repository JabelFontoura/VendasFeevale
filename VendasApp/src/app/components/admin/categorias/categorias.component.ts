import { Component, OnInit } from '@angular/core';
import { CategoriasService } from '../../../services/categorias.service';
import { Router } from '@angular/router';
import { Categoria } from '../../../entities/categoria.entity';


@Component({
  selector: 'app-categorias',
  templateUrl: './categorias.component.html',
  styleUrls: ['./categorias.component.css']
})
export class CategoriasComponent implements OnInit {

  public categorias: Categoria[];

  constructor(
    private categoriasService: CategoriasService,
    private router: Router
  ) { }

  ngOnInit() {
    this.carregarCategorias();
  }

  carregarCategorias() {
    this.categoriasService.findAll()
    .subscribe(data => this.categorias = <any> data);
  }

  editar(id: string): void {
    this.router.navigate(['/admin/categorias/editar', id]);
  }

  deletar(id: string) {
    this.categoriasService.delete(id).subscribe(result => this.carregarCategorias());
  }
}
