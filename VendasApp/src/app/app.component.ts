import { ProdutosService } from './services/produtos.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';

  constructor(private service: ProdutosService) {
    service.findAll().subscribe(resp => console.log(resp));
  }
}
