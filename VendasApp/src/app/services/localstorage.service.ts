import {Injectable} from '@angular/core';
import {Http, Headers} from '@angular/http';

@Injectable()
export class LocalStorageService {

  constructor() {}

  getAuthToken() {
    return localStorage.getItem('authToken');
  }

  setAuthToken(token: string) {
    localStorage.setItem('authToken', token);
  }
}
