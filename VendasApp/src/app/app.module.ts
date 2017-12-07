import { FormsModule } from '@angular/forms';
import { ComumModule } from './components/comum/comum.module';
import { AppRoutingModule } from './app.routing.module';
import { AuthModule } from './components/auth/auth.module';
import { PrecosService } from './services/precos.service';
import { UsuariosService } from './services/usuarios.service';
import { LocalStorageService } from './services/localstorage.service';
import { HttpClient } from './services/http-client.service';
import { HttpModule } from '@angular/http';
import { ProdutosService } from './services/produtos.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { CategoriasService } from './services/categorias.service';
import { CabecalhoVendasService } from './services/cabecalho-vendas.service';
import { DetalheVendasService } from './services/detalhe-vendas.service';
import { AdminModule } from './components/admin/admin.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    AuthModule,
    ComumModule,
    AdminModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [
    HttpClient,
    UsuariosService,
    ProdutosService,
    CategoriasService,
    PrecosService,
    CabecalhoVendasService,
    DetalheVendasService,
    LocalStorageService
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
