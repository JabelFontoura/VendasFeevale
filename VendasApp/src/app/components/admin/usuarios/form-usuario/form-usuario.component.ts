import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UsuariosService } from '../../../../services/usuarios.service';
import { selector } from 'rxjs/operator/publish';
import { Usuario } from '../../../../entities/usuario.entity';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-form-usuario',
  templateUrl: './form-usuario.component.html',
  styleUrls: ['./form-usuario.component.css']
})
export class FormUsuarioComponent implements OnInit {

  public salvar: Function;
  public editando: boolean;
  public usuario = new Usuario();

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private usuariosService: UsuariosService
  ) { }

  ngOnInit() {
    this.definirContexto();
  }

  onSubmit(f: FormGroup) {
    this.salvar(this.usuario);
  }

  definirContexto(): void {
    this.route.params.subscribe(params => {
      const { id } = params;
      if (id) {
        this.usuariosService.findById(id).subscribe(data => {
          if (data) {
            this.usuario = <any> data;
            this.salvar = this.editar;
            this.editando = true;
          } else {
            this.router.navigate(['/admin/usuarios/novo']);
          }
        });
      } else {
        this.salvar = this.adicionar;
        this.editando = false;
      }
    });
  }

  private adicionar = (usuario: Usuario): void  => {
    this.usuariosService.add(usuario).subscribe(result => this.router.navigate(['/admin/usuarios']));
  }

  private editar = (usuario: Usuario): void => {
    this.usuariosService.update(usuario).subscribe(result => this.router.navigate(['/admin/usuarios']));
  }

}
