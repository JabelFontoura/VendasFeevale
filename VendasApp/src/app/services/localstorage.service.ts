import {Injectable} from '@angular/core';
import {Http, Headers} from '@angular/http';

@Injectable()
export class LocalStorageService {

  constructor() {}

  getAuthToken() {
    return JSON.parse(localStorage.getItem('authToken'));
  }

  setAuthToken(token: string) {
    localStorage.setItem('authToken', token);
  }
}
