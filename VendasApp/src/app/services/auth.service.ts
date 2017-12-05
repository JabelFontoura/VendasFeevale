import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable()
export class AuthService {

  private authUrl = `${environment.authUrl}/login`;

  constructor(private http: Http) { }

  login(credenciais: any): Observable<Response> {
    return this.http.post(this.authUrl, credenciais)
      .map(resp => resp.json())
      .catch(this.handleError);
  }

  private handleError (error: Response | any): Observable<Response> {
    return Observable.throw(error || 'Server error');
  }
}
