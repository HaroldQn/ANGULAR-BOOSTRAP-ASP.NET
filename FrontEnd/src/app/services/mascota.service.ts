import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { Mascota } from '../models/macota';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MascotaService {

  constructor(private http: HttpClient) { }

  url:string = "https://localhost:44372/api/mascota";

  getMascotas() {
    return this.http.get(this.url);
  }

  addMascota(mascota:Mascota):Observable<Mascota>{
    return this.http.post<Mascota>(this.url, mascota);
  }
  updateMascota(id:number,mascota:Mascota):Observable<Mascota>{
    return this.http.put<Mascota>(this.url+ `/${id}`, mascota);
  }

  deteleMascota(id:number):Observable<Mascota>{
    return this.http.delete<Mascota>(this.url+ `/${id}`);
  }
}
