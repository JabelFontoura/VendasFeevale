import { Observable } from 'rxjs/Rx';

export interface IService<T> {
  findAll(): any;
  findById(id: string): Observable<Response>;
  add(entity: T): Observable<Response>;
  delete(id: string): Observable<Response>;
  update(entity: T): Observable<Response>;
}