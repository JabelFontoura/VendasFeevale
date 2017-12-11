import { ComumRoutingModule } from './comum.routing.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { ProdutosComponent } from './produtos/produtos.component';
import { CategoriasComponent } from './categorias/categorias.component';
import { CarrinhoComponent } from './carrinho/carrinho.component';

@NgModule({
  imports: [
    CommonModule,
    ComumRoutingModule,
  ],
  declarations: [
    HomeComponent,
    ProdutosComponent,
    CategoriasComponent,
    CarrinhoComponent
  ]
})
export class ComumModule { }
