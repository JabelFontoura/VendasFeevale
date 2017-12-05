import { LocalStorageService } from './services/localstorage.service';
import { HttpClient } from './services/http-client.service';
import { HttpModule } from '@angular/http';
import { ProdutosService } from './services/produtos.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpModule
  ],
  providers: [
    ProdutosService,
    HttpClient,
    LocalStorageService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
