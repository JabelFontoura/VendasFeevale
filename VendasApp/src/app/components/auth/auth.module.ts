import { AuthService } from '../../services/auth.service';
import { FormsModule } from '@angular/forms';
import { AuthRoutingModule } from './auth.routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';

@NgModule({
  imports: [
    CommonModule,
    AuthRoutingModule,
    FormsModule
  ],
  declarations: [LoginComponent],
  providers: [
    AuthService
  ]
})
export class AuthModule { }
