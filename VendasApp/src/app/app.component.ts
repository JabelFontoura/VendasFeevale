import { Router } from '@angular/router';
import { UsuariosService } from './services/usuarios.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';

  constructor(
    private usuariosService: UsuariosService,
    private router: Router
  ) { }

  ngOnInit() {
    this.usuariosService.verifyUser()
      .subscribe(result => this.router.navigate(['']), error => this.router.navigate(['/auth']));
  }

}
