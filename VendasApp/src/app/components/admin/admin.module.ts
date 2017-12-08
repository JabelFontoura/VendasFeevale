import { FormsModule } from '@angular/forms';
import { FormProdutoComponent } from './produtos/form-produto/form-produto.component';
import { AdminRoutingModule } from './admin.routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { ProdutosComponent } from './produtos/produtos.component';

@NgModule({
  imports: [
    CommonModule,
    AdminRoutingModule,
    FormsModule
  ],
  declarations: [
    HomeComponent,
    ProdutosComponent,
    FormProdutoComponent
  ]
})
export class AdminModule { }
