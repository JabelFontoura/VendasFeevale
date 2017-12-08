import { Tipo } from '../../../entities/enums/tipo.enum';
import { UsuariosService } from '../../../services/usuarios.service';
import { LocalStorageService } from '../../../services/localstorage.service';
import { Router } from '@angular/router';
import { FormGroup } from '@angular/forms';
import { AuthService } from '../../../services/auth.service';
import { Usuario } from '../../../entities/usuario.entity';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public usuario: Usuario;

  constructor(
    private authService: AuthService,
    private localStorageService: LocalStorageService,
    private usuariosService: UsuariosService,
    private router: Router
  ) { }

  ngOnInit() {
    this.usuario = new Usuario();

    if (this.localStorageService.getAuthToken()) {
      this.definirPath();
    }
  }

  definirPath(): void {
    this.usuariosService.verifyUser().subscribe(result => {
      const { tipo } = <any> result;
    
      if (tipo === Tipo.admin) {
        this.router.navigate(['/admin']);
      } else {
        this.router.navigate(['/loja']);
      }
    });
  }

  onSubmit(form: FormGroup) {
    if (form.valid) {
      const { login, senha } = this.usuario;

      this.authService.login({ login, senha})
        .subscribe(result => {
          this.localStorageService.setAuthToken(result['accessToken']);
          this.localStorageService.setLogin(login);
          this.definirPath();
        });
    }
  }

}
