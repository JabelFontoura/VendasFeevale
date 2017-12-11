import { Observable } from 'rxjs/Rx';
import { IService } from './iservice.interface';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from './http-client.service';
import { DetalheVenda } from '../entities/detalhe-venda.entity';

@Injectable()
export class DetalheVendasService implements IService<DetalheVenda> {

  constructor(private http: HttpClient) { }

  private apiUrl = `${environment.apiUrl}/detalheVendas`;

  public findAll(): Observable<Response> {
    return this.http.get(this.apiUrl)
    .map(resp => resp.json())
    .catch(this.handleError);
  }

  public findByIdCabecalhoVenda(id: string): Observable<Response> {
    return this.http.get(`${this.apiUrl}/cabecalhoVenda/${id}`)
      .map(resp => resp.json())
      .catch(this.handleError);
  }

  public findById(id: string): Observable<Response> {
    return this.http.get(`${this.apiUrl}/${id}`)
      .map(resp => resp.json())
      .catch(this.handleError);
  }

  public add(entity: DetalheVenda): Observable<Response> {
    return this.http.post(this.apiUrl, entity)
    .map(resp => resp.json())
    .catch(this.handleError);
  }

  public delete(id: string): Observable<Response> {
    return this.http.delete(`${this.apiUrl}/${id}`)
      .map(resp => resp.json())
      .catch(this.handleError);
  }

  public update(entity: DetalheVenda): Observable<Response> {
    return this.http.put(this.apiUrl, entity)
    .map(resp => resp.json())
    .catch(this.handleError);
  }

  private handleError (error: Response | any): Observable<Response> {
      return Observable.throw(error || 'Server error');
  }
}
