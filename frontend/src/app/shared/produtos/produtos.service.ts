import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Produto } from '../../shared/produto'

@Injectable({
  providedIn: 'root'
})
export class ProdutosService {
  private baseURL = 'https://localhost:7076/api/Produtos';

  constructor(private https: HttpClient) { }

  get(): Observable<Produto[]>{
    return this.https.get<Produto[]>(this.baseURL);
  }

  getById(id: number): Observable<Produto>{
    return this.https.get<Produto>(`${this.baseURL}/${id}`);
  }

  post(produto: Produto): Observable<Produto>{
    return this.https.post<Produto>(this.baseURL, produto);
  }

  delete(id: number){
    return this.https.delete<Produto>(`${this.baseURL}/${id}`);
  }
}
