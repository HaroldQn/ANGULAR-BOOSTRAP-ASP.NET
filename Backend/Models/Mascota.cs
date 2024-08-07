using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class Mascota
    {
        public int idmascota { get; set; }
        public int idraza { get; set; }
        public string nombre_mascota { get; set; }


        public Mascota() { }

        public Mascota(int id, int Idraza, string Nombre_mascota) 
        {
            idmascota = id;
            idraza = Idraza;
            nombre_mascota = Nombre_mascota;
        }

        public Mascota(int Idraza, string Nombre_mascota)
        {
            idraza = Idraza;
            nombre_mascota = Nombre_mascota;
        }
    }
}