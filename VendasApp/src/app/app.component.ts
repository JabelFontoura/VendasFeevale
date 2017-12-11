import { LocalStorageService } from './services/localstorage.service';
import { Usuario } from './entities/usuario.entity';
import { Router } from '@angular/router';
import { UsuariosService } from './services/usuarios.service';
import { Component, OnInit, SimpleChanges } from '@angular/core';
import { OnChanges } from '@angular/core/src/metadata/lifecycle_hooks';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';

  public usuario = new Usuario();

  constructor(
    private usuariosService: UsuariosService,
    private router: Router,
    private localStorageService: LocalStorageService
  ) { }

  ngOnInit() {
    if (this.localStorageService.getAuthToken()) {
      this.usuariosService.verifyUser()
        .subscribe(result => {
          this.usuario = <any> result;
          this.router.navigate(['']);
        }, error => this.router.navigate(['/auth']));
    } else {
      this.router.navigate(['/auth']);
    }

  }

  logOff(): void {
    this.localStorageService.clearAll();
    this.router.navigate(['']);
    window.location.reload();
  }
}
