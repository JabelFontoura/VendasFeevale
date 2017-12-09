import { ProdutosComponent } from './produtos/produtos.component';
import { FormProdutoComponent } from './produtos/form-produto/form-produto.component';

import { CategoriasComponent } from './categorias/categorias.component';
import { FormCategoriaComponent } from './categorias/form-categoria/form-categoria.component';

import { PrecosComponent } from './precos/precos.component';
import { FormPrecoComponent } from './precos/form-preco/form-preco.component';

import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full' },

    { path: 'admin/produtos', component: ProdutosComponent, pathMatch: 'full' },
    { path: 'admin/produtos/novo', component: FormProdutoComponent, pathMatch: 'full' },
    { path: 'admin/produtos/editar/:id', component: FormProdutoComponent, pathMatch: 'full' },

    { path: 'admin/categorias', component: CategoriasComponent, pathMatch: 'full' },
    { path: 'admin/categorias/novo', component: FormCategoriaComponent, pathMatch: 'full' },
    { path: 'admin/categorias/editar/:id', component: FormCategoriaComponent, pathMatch: 'full' },

    { path: 'admin/precos', component: PrecosComponent, pathMatch: 'full' },
    { path: 'admin/precos/novo', component: FormPrecoComponent, pathMatch: 'full' },
    { path: 'admin/precos/editar/:id', component: FormPrecoComponent, pathMatch: 'full' },

];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class AdminRoutingModule { }
