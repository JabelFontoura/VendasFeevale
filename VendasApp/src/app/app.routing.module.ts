import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    { path: '', loadChildren: 'app/captura/analise-credito/analise-credito.module#AnaliseCreditoModule' },
    { path: 'auth', loadChildren: 'app/captura/captura.module#CapturaModule' },
    { path: 'admin', loadChildren: 'app/acompanhamento/acompanhamento.module#AcompanhamentoModule' },
    { path: '**', redirectTo: '' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes, { useHash: true })],
    exports: [RouterModule]
})

export class AppRoutingModule { }
