import { PrecosService } from '../../../services/precos.service';
import { selector } from 'rxjs/operator/publish';
import { Preco } from '../../../entities/preco.entity';
import { Produto } from '../../../entities/produto.entity';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-precos',
  templateUrl: './precos.component.html',
  styleUrls: ['./precos.component.css']
})
export class PrecosComponent implements OnInit {

  public precos: Preco[];

  constructor(
    private router: Router,
    private precosService: PrecosService,
  ) { }

  ngOnInit() {
    this.carregarPrecos();
  }

  carregarPrecos() {
    this.precosService.findAll()
    .subscribe(data => this.precos = <any> data);
  }

  editar(id: string): void {
    this.router.navigate(['/admin/precos/editar', id]);
  }

  deletar(id: string) {
    this.precosService.delete(id).subscribe(result => this.carregarPrecos());
  }
}
