import { Situacao } from '../entities/enums/situacao.enum';
import { Observable } from 'rxjs/Rx';
import { IService } from './iservice.interface';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from './http-client.service';
import { CabecalhoVenda } from '../entities/cabecalho-venda.entity';

@Injectable()
export class CabecalhoVendasService implements IService<CabecalhoVenda> {

  constructor(private http: HttpClient) { }

  private apiUrl = `${environment.apiUrl}/cabecalhoVendas`;

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

  public findByIdUsuarioAndSituacao(id: string, s: Situacao): Observable<Response> {
    return this.http.get(`${this.apiUrl}/usuario/${id}/${this.mapSituacao(s)}`)
      .map(resp => resp.json())
      .catch(this.handleError);
  }

  public findByIdUsuario(id: string): Observable<Response> {
    return this.http.get(`${this.apiUrl}/usuario/${id}`)
      .map(resp => resp.json())
      .catch(this.handleError);
  }

  public add(entity: CabecalhoVenda): Observable<Response> {
    return this.http.post(this.apiUrl, entity)
    .map(resp => resp.json())
    .catch(this.handleError);
  }

  public delete(id: string): Observable<Response> {
    return this.http.delete(`${this.apiUrl}/${id}`)
      .map(resp => resp.json())
      .catch(this.handleError);
  }

  public update(entity: CabecalhoVenda): Observable<Response> {
    return this.http.put(this.apiUrl, entity)
    .map(resp => resp.json())
    .catch(this.handleError);
  }

  private handleError (error: Response | any): Observable<Response> {
      return Observable.throw(error || 'Server error');
  }

  private mapSituacao(s: Situacao): string {
    switch (s) {
      case 0:
        return 'pendente';
      case 1:
        return 'aprovado';
      case 3:
        return 'reprovado';
    }
  }
}
