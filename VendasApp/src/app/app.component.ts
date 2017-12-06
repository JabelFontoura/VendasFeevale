import { UsuariosService } from './services/usuarios.service';
import { ProdutosService } from './services/produtos.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';

  constructor(private usuariosService: UsuariosService) { }

  ngOnInit() {
    this.usuariosService.verifyUser()
      .subscribe(resp => {
        console.log(resp);
      });
  }

}
