import { CarrinhoComponent } from './carrinho/carrinho.component';
import { HomeComponent } from './home/home.component';
import { ProdutosComponent } from './produtos/produtos.component';
import { CategoriasComponent } from './categorias/categorias.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'loja/produtos', component: ProdutosComponent, pathMatch: 'full' },
    { path: 'loja/categorias', component: CategoriasComponent, pathMatch: 'full' },
    { path: 'loja/carrinho', component: CarrinhoComponent, pathMatch: 'full' },
    { path: 'loja', redirectTo: '/loja/produtos', pathMatch: 'full' },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class ComumRoutingModule { }
