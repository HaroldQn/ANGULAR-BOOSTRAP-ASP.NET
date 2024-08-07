import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Mascota } from './models/macota';
import { MascotaService } from './services/mascota.service';

import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  mascota:Mascota = new Mascota();
  datatable:any = [];

  constructor(private mascotaService:MascotaService){

  }

  ngOnInit(): void {
    this.onDataTable();
  }

  onDataTable(){
    this.mascotaService.getMascotas().subscribe(
      res =>{
        this.datatable = res;
        console.log(res)
      }
    )
  }

  onSetData(select:any){
    this.mascota.idmascota = select.idmascota;
    this.mascota.idraza = select.idraza;
    this.mascota.nombre_mascota = select.nombre_mascota;
  }

  clear()
  {
    this.mascota.idmascota = 0;
    this.mascota.idraza = 0;
    this.mascota.nombre_mascota = "";
  }

  onAddMascota(mascota:Mascota):void{
    this.mascotaService.addMascota(mascota).subscribe(res =>{
      if(res) {
        alert("Mascota Agregada");
        this.onDataTable();
        this.clear();
      }else{
        alert("Mascota no Agregada");
        this.clear();
      }
    }
      
    )
  }

  updateAddMascota(mascota:Mascota):void{
    this.mascotaService.updateMascota(mascota.idmascota, mascota).subscribe(
      res =>{
        this.onDataTable();
        this.clear();
      }
    )
  }

  onDeteleMascota(id:number):void{
    this.mascotaService.deteleMascota(id).subscribe(
      res =>{
        this.onDataTable();
        this.clear();
      }
    )
  }
}
