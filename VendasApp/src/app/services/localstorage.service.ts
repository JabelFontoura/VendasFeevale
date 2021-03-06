import {Injectable} from '@angular/core';
import {Http, Headers} from '@angular/http';

@Injectable()
export class LocalStorageService {

  constructor() {}

  getAuthToken(): string {
    return localStorage.getItem('authToken');
  }

  setAuthToken(token: string): void {
    localStorage.setItem('authToken', token);
  }

  getLogin(): string {
    return localStorage.getItem('userLogin');
  }

  setLogin(login: string) {
    localStorage.setItem('userLogin', login);
  }

  getIdUsuario(): string {
    return localStorage.getItem('userId');
  }

  setIdUsuario(id: string) {
    localStorage.setItem('userId', id);
  }

  clearAll(): void {
    localStorage.clear();
  }
}
