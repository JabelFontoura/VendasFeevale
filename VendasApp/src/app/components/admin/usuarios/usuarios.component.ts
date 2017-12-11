import { Usuario } from '../../../entities/usuario.entity';
import { UsuariosService } from '../../../services/usuarios.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  public usuarios: Usuario[];

  constructor(
    private router: Router,
    private usuariosService: UsuariosService
  ) { }

  ngOnInit() {
    this.carregarUsuarios();
  }

  carregarUsuarios(): void {
    this.usuariosService.findAll().subscribe(data => this.usuarios = <any> data);
  }

  editar(id: string): void {
    this.router.navigate(['/admin/usuarios/editar', id]);
  }

  deletar(id: string) {
    this.usuariosService.delete(id).subscribe(result => this.carregarUsuarios());
  }
}
