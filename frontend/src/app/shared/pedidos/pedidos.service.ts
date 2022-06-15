import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Pedido } from 'src/app/shared/pedido';

@Injectable({
  providedIn: 'root'
})
export class PedidosService {
  private baseURL = 'https://localhost:7076/api/Pedidos';
  constructor(private https: HttpClient) { }

  get(): Observable<Pedido[]> {
    return this.https.get<Pedido[]>(this.baseURL);
  }

  getById(id: number): Observable<Pedido> {
    return this.https.get<Pedido>(`${this.baseURL}/${id}`);
  }

  post(pedido: Pedido): Observable<Pedido> {
    return this.https.post<Pedido>(this.baseURL, pedido);
  }

  delete(id: number){
    return this.https.delete<Pedido>(`${this.baseURL}/${id}`);
  }

  getPedidoCliente(id: number): Observable<Pedido> {
    return this.https.get<Pedido>(`${this.baseURL}/Cliente/${id}`);
  }

  getPedidoAbertoCliente(id: number): Observable<Pedido> {
    return this.https.get<Pedido>(`${this.baseURL}/Aberto/Cliente/${id}`);
  }
}
