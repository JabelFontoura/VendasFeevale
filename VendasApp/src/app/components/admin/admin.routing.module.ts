import { FormProdutoComponent } from './produtos/form-produto/form-produto.component';
import { ProdutosComponent } from './produtos/produtos.component';
import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'admin/produtos', component: ProdutosComponent, pathMatch: 'full' },
    { path: 'admin/produtos/novo', component: FormProdutoComponent, pathMatch: 'full' },
    { path: 'admin/produtos/editar/:id', component: FormProdutoComponent, pathMatch: 'full' },

];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class AdminRoutingModule { }
