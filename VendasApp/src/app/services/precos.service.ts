import { Preco } from '../entities/preco.entity';
import { Observable } from 'rxjs/Rx';
import { IService } from './iservice.interface';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from './http-client.service';

@Injectable()
export class PrecosService implements IService<Preco> {

  constructor(private http: HttpClient) { }

  private apiUrl = `${environment.apiUrl}/usuarios`;

  public findAll(): Observable<Response> {
    return this.http.get(this.apiUrl)
    .map(resp => resp.json())
    .catch(this.handleError);
  }

  public findById(id: string): Observable<Response> {
    return this.http.get(`${this.apiUrl}/${id}`)
      .map(resp => resp.json())
      .catch(this.handleError);
  }

  public add(entity: Preco): Observable<Response> {
    return this.http.post(this.apiUrl, entity)
    .map(resp => resp.json())
    .catch(this.handleError);
  }

  public delete(id: string): Observable<Response> {
    return this.delete(`${this.apiUrl}/${id}`);
  }

  public update(entity: Preco): Observable<Response> {
    return this.http.put(this.apiUrl, entity)
    .map(resp => resp.json())
    .catch(this.handleError);
  }

  private handleError (error: Response | any): Observable<Response> {
      return Observable.throw(error || 'Server error');
  }
}
