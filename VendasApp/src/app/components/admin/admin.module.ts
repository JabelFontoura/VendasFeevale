import { FormsModule } from '@angular/forms';
import { FormProdutoComponent } from './produtos/form-produto/form-produto.component';
import { FormPrecoComponent } from './precos/form-preco/form-preco.component';
import { FormCategoriaComponent } from './categorias/form-categoria/form-categoria.component';
import { AdminRoutingModule } from './admin.routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { PrecosComponent } from './precos/precos.component';
import { ProdutosComponent } from './produtos/produtos.component';
import { CategoriasComponent } from './categorias/categorias.component';

@NgModule({
  imports: [
    CommonModule,
    AdminRoutingModule,
    FormsModule
  ],
  declarations: [
    HomeComponent,
    CategoriasComponent,
    PrecosComponent,
    ProdutosComponent,
    FormCategoriaComponent,
    FormPrecoComponent,
    FormProdutoComponent
  ]
})
export class AdminModule { }
