import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Usuario } from 'src/app/shared/usuario';

@Injectable({
  providedIn: 'root'
})
export class ClientesService {

  private baseURL = 'https://localhost:7076/api/Clientes';

  constructor(private https: HttpClient) { }

  get() : Observable<Usuario[]> {
    return this.https.get<Usuario[]>(this.baseURL);
  }

  getById(id: number): Observable<Usuario>{
    return this.https.get<Usuario>(`${this.baseURL}/${id}`);
  }

  post(cliente: Usuario): Observable<Usuario>{
    return this.https.post<Usuario>(`${this.baseURL}`, cliente)
  }

  delete(id: number){
    return this.https.delete<Usuario>(`${this.baseURL}/${id}`)
  }
}
